document.getElementById('start-button').addEventListener('click', startGame);
document.getElementById('submit-guess').addEventListener('click', submitGuess);
document.getElementById('play-again').addEventListener('click', resetGame);

let pokemonData = null;
let currentStep = 0;

const steps = [
    { id: 'name', group: 'guess-name-group', input: 'guess-name', correctDisplay: 'correct-name' },
    { id: 'type1', group: 'guess-type1-group', input: 'guess-type1', correctDisplay: 'correct-type1' },
    { id: 'type2', group: 'guess-type2-group', input: 'guess-type2', correctDisplay: 'correct-type2', condition: () => pokemonData && pokemonData.typeTwo },
    { id: 'evolutions', group: 'guess-evolutions-group', input: 'guess-evolutions', correctDisplay: 'correct-evolutions', condition: () => pokemonData && pokemonData.evolutions && pokemonData.evolutions.length > 0 }
];

async function startGame() {
    try {
        const response = await fetch('/Home/GetRandomPokemon', {
            method: 'GET',
            headers: { 'Accept': 'application/json' }
        });

        if (response.status === 204) {
            throw new Error('No Pokémon data available');
        }

        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(errorData.error || 'Failed to fetch Pokémon data');
        }

        pokemonData = await response.json();

        if (!pokemonData || !pokemonData.name) {
            throw new Error('Invalid Pokémon data received');
        }

        const pokemonImage = document.getElementById('pokemon-image');
        if (pokemonData.silhouette) {
            pokemonImage.src = `data:image/png;base64,${pokemonData.silhouette}`;
            pokemonImage.alt = 'Pokémon Silhouette';
        } else {
            pokemonImage.src = '';
            pokemonImage.alt = 'No silhouette available';
        }

        currentStep = 0;
        showStep(currentStep);

        document.getElementById('start-section').style.display = 'none';
        document.getElementById('game-section').style.display = 'block';
        document.getElementById('result-section').style.display = 'none';
        document.getElementById('error-message').style.display = 'none';
    } catch (error) {
        console.error('Error:', error);
        document.getElementById('error-message').textContent = `An error occurred: ${error.message}`;
        document.getElementById('error-message').style.display = 'block';
    }
}

function showStep(stepIndex) {
    steps.forEach(step => {
        document.getElementById(step.group).style.display = 'none';
    });

    const errorMessage = document.getElementById('error-message');
    errorMessage.style.display = 'none';
    errorMessage.textContent = '';

    let current = steps[stepIndex];
    while (current && current.condition && !current.condition()) {
        stepIndex++;
        current = steps[stepIndex];
    }

    if (current && stepIndex < steps.length) {
        document.getElementById(current.group).style.display = 'block';
        document.getElementById(current.input).focus();
        currentStep = stepIndex;
    } else {
        showResult();
    }
}

function submitGuess() {
    if (currentStep === null || currentStep >= steps.length) {
        showResult();
        return;
    }

    const current = steps[currentStep];
    const input = document.getElementById(current.input).value.trim().toLowerCase();
    const errorMessage = document.getElementById('error-message');

    let correct = false;
    let correctValue = '';

    switch (current.id) {
        case 'name':
            correct = input === pokemonData.name.toLowerCase();
            correctValue = pokemonData.name;
            if (correct) {
                const pokemonImage = document.getElementById('pokemon-image');
                if (pokemonData.image) {
                    pokemonImage.src = `data:image/png;base64,${pokemonData.image}`;
                    pokemonImage.alt = pokemonData.name;
                }
                const correctName = document.getElementById('correct-name');
                correctName.textContent = `Name: ${pokemonData.name}`;
                correctName.style.display = 'block';
            }
            break;
        case 'type1':
            correct = input === pokemonData.typeOne.toLowerCase();
            correctValue = pokemonData.typeOne;
            if (correct) {
                const correctType1 = document.getElementById('correct-type1');
                correctType1.textContent = `Type 1: ${pokemonData.typeOne}`;
                correctType1.style.display = 'block';
            }
            break;
        case 'type2':
            const expectedType2 = pokemonData.typeTwo ? pokemonData.typeTwo.toLowerCase() : '';
            correct = input === expectedType2;
            correctValue = pokemonData.typeTwo || 'None';
            if (correct) {
                const correctType2 = document.getElementById('correct-type2');
                correctType2.textContent = `Type 2: ${pokemonData.typeTwo || 'None'}`;
                correctType2.style.display = 'block';
            }
            break;
        case 'evolutions':
            const guessEvolutions = input.split(',').map(e => e.trim().toLowerCase()).filter(e => e).sort();
            const correctEvolutions = pokemonData.evolutions ? pokemonData.evolutions.map(e => e.name.toLowerCase()).sort() : [];
            correct = guessEvolutions.length === correctEvolutions.length &&
                guessEvolutions.every((e, i) => e === correctEvolutions[i]);
            correctValue = correctEvolutions.join(', ') || 'None';
            if (correct) {
                const correctEvolutionsDisplay = document.getElementById('correct-evolutions');
                correctEvolutionsDisplay.textContent = `Evolutions: ${correctEvolutions.join(', ') || 'None'}`;
                correctEvolutionsDisplay.style.display = 'block';
            }
            break;
    }

    if (correct) {
        currentStep++;
        document.getElementById(current.input).value = '';
        showStep(currentStep);
    } else {
        errorMessage.textContent = `Incorrect! Try again.`;
        errorMessage.style.display = 'block';
        document.getElementById(current.input).focus();
    }
}

function showResult() {
    const resultMessage = document.getElementById('result-message');
    resultMessage.textContent = `Congratulations! You guessed ${pokemonData ? pokemonData.name : 'the Pokémon'} correctly!`;
    resultMessage.style.color = 'green';

    document.getElementById('game-section').style.display = 'none';
    document.getElementById('result-section').style.display = 'block';

    const resultImage = document.getElementById('pokemon-image-result');
    if (pokemonData && pokemonData.image) {
        resultImage.src = `data:image/png;base64,${pokemonData.image}`;
        resultImage.alt = pokemonData.name || 'Pokémon Image';
    } else {
        resultImage.src = '';
        resultImage.alt = 'No image available';
    }

    document.getElementById('play-again').style.display = 'block';
}

function resetGame() {
    steps.forEach(step => {
        document.getElementById(step.input).value = '';
        document.getElementById(step.group).style.display = 'none';
        document.getElementById(step.correctDisplay).style.display = 'none';
        document.getElementById(step.correctDisplay).textContent = '';
    });

    document.getElementById('pokemon-image').src = '';
    document.getElementById('pokemon-image').alt = '';
    document.getElementById('pokemon-image-result').src = '';
    document.getElementById('pokemon-image-result').alt = '';

    document.getElementById('result-message').textContent = '';
    document.getElementById('error-message').textContent = '';
    document.getElementById('error-message').style.display = 'none';

    document.getElementById('start-section').style.display = 'block';
    document.getElementById('game-section').style.display = 'none';
    document.getElementById('result-section').style.display = 'none';
    document.getElementById('submit-guess').disabled = false;

    pokemonData = null;
    currentStep = 0;
}
# 🌟 RandomPokémon: A Pokémon Web Adventure

[![.NET](https://img.shields.io/badge/.NET-9.0-blueviolet)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-green)](LICENSE)

A dynamic and engaging web application for Pokémon fans to explore, guess, and dive deep into the world of Pokémon. Built with modern .NET technologies, RandomPokémon integrates with a Pokémon API to deliver a fun and interactive experience.

## 🚀 Technologies Used
- **Backend**: .NET 9.0, Clean Architecture, Domain-Driven Design (DDD)
- **Frontend**: ASP.NET Core MVC, Bootstrap 5, jQuery
- **Database**: SQLite
- **API**: Pokémon API
- **Tools**: Visual Studio, Git

## 🎯 Purpose
- Provide an interactive platform for Pokémon enthusiasts to browse the Pokédex, play a guessing game, and view detailed Pokémon stats.
- Showcase modern .NET development practices with a modular and scalable architecture.
- Serve as a portfolio project demonstrating web development, API integration, and database management.

## 🌟 Key Features
- **Pokémon List**: Browse the complete Pokédex with data fetched in real-time from the Pokémon API.
- **Who's that Pokémon?**: A fun guessing game to identify Pokémon by their silhouettes and attributes.
- **Pokémon Details**: Search and view detailed information, including types, evolutions, and images.
- **Search Bar**: Quickly find any Pokémon by name from any page.
- **Responsive Design**: A consistent UI with a modern footer across all pages, optimized for desktop and mobile.
- **Clean Architecture**: Modular backend with Api, Contracts, Data, Domain, and Services projects.

## 📈 Highlighted Features
- **Guess Game**: Test your Pokémon knowledge with a silhouette-based quiz.
- **Search Functionality**: Instant Pokémon lookup via a navbar search bar.
- **Detailed Stats**: Explore Pokémon types, evolutions, and images in a clean, card-based layout.
- **SQLite Integration**: Efficient data persistence for game state and user interactions.
- **Modern UI**: Styled with Bootstrap 5 and custom CSS for a Pokémon-themed experience.

## 📂 Project Structure
- **Api**: REST endpoints for Pokémon data.
- **Contracts**: Interfaces and DTOs for communication.
- **Data**: SQLite database access and repositories.
- **Domain**: Business logic and entities.
- **Services**: Application logic and orchestration.
- **RandomPokemon.WebSite**: ASP.NET Core MVC frontend.

## 🛠️ How to Use
1. **Clone the repository**:
   ```bash
   git clone https://github.com/GustavoMariano/RandomPokemon.git
   ```
2. **Install dependencies**:
   ```bash
   dotnet restore
   ```
3. **Configure settings**:
   - Update the Pokémon API URL in `RandomPokemon.WebSite.Controllers.HomeController.cs`.
4. **Run the application**:
   ```bash
   dotnet run
   ```
5. **Explore**:
   - Browse the Pokédex, play the guessing game, or search for your favorite Pokémon!

## 🔗 Useful Resources
- [ASP.NET Core Documentation](https://learn.microsoft.com/en-us/aspnet/core/) - Learn about MVC and .NET 9.0.
- [Bootstrap 5](https://getbootstrap.com/docs/5.0/) - UI framework used for styling.
- [SQLite](https://www.sqlite.org/) - Lightweight database used for persistence.

## 📝 License
This project is licensed under the [MIT License](LICENSE). Feel free to use it for educational purposes, personal projects, or as inspiration for your own Pokémon adventures!

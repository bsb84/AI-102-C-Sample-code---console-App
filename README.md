# AI-102 C# Sample Code - Console App & Web App

This repository contains sample C# code for building both console and web applications related to AI-102 certification topics. The code is designed to help developers understand and implement AI solutions using C# in both console and web environments.

## Projects

### 1. Console Application (Ai-console.csproj)
- **Project Type**: Console Application
- **Features**: Language detection, key phrase extraction, entity recognition, PII recognition, and sentiment analysis
- **Services**: Azure AI Text Analytics

### 2. Web Application (TextTranslatorWebApp)
- **Project Type**: ASP.NET Core Web Application
- **Features**: Text translation with multiselect dropdown for target languages
- **Services**: Azure AI Translation Service
- **UI**: Responsive web interface with Bootstrap

## Overview

- **Language**: C#
- **Framework**: .NET 8.0
- **Repository**: [bsb84/AI-102_CSharp_Sample_code---April_2025-Updates](https://github.com/bsb84/AI-102_CSharp_Sample_code---April_2025-Updates)
- **Author**: [BSB](https://github.com/bsb84)
- **Description**: AI 102 C# Sample code demonstrating key AI concepts and solutions for Microsoft AI-102 certification.

## Features

### Console Application Features
- Language detection example
- Key phrase extraction
- Named entity recognition
- PII (Personally Identifiable Information) recognition
- Sentiment analysis
- Well-structured code to support learning and experimentation

### Web Application Features
- **Text Translation**: Translate text into multiple languages simultaneously
- **Multiselect Interface**: Choose from 18 different target languages with checkboxes
- **Select All/Clear All**: Convenient buttons to manage language selection
- **Copy to Clipboard**: Copy translated results with one click
- **Responsive Design**: Bootstrap-based UI that works on all devices
- **Error Handling**: Comprehensive error handling and user feedback

## Getting Started

### Console Application
1. **Clone the repository**
   ```bash
   git clone https://github.com/bsb84/AI-102_CSharp_Sample_code---April_2025-Updates.git
   ```
2. **Navigate to the project directory**
   ```bash
   cd AI-102_CSharp_Sample_code---April_2025-Updates
   ```
3. **Set up environment variables for Azure AI Text Analytics:**
   ```bash
   export LANGUAGE_KEY="your-azure-language-key"
   export LANGUAGE_ENDPOINT="your-azure-language-endpoint"
   ```
4. **Build and run the console app**
   ```bash
   dotnet build
   dotnet run
   ```

### Web Application
1. **Navigate to the web app directory**
   ```bash
   cd TextTranslatorWebApp
   ```
2. **Set up environment variables for Azure Translator:**
   ```bash
   export TRANSLATOR_KEY="your-azure-translator-key"
   export TRANSLATOR_ENDPOINT="your-azure-translator-endpoint"
   ```
3. **Build and run the web app**
   ```bash
   dotnet build
   dotnet run
   ```
4. **Open your browser** and navigate to `http://localhost:5000`

For detailed setup instructions for the web application, see [TextTranslatorWebApp/README.md](TextTranslatorWebApp/README.md).

## Reference

### Azure AI Services Setup
- **Text Analytics**: [Language Detection Quickstart](https://learn.microsoft.com/en-us/azure/ai-services/language-service/language-detection/quickstart?tabs=windows&pivots=programming-language-csharp)
- **Translator Service**: [Translator Service Documentation](https://learn.microsoft.com/en-us/azure/ai-services/translator/)

### Supported Languages (Web App)
The web application supports translation to 18 languages: Spanish, French, German, Italian, Portuguese, Russian, Japanese, Korean, Chinese (Simplified), Arabic, Hindi, Turkish, Polish, Dutch, Swedish, Danish, Norwegian, and Finnish.
   
   

## Usage

This repository is intended for educational purposes and hands-on learning for the AI-102 certification. Explore the code, modify it, and run experiments to deepen your understanding of AI concepts in C#.

## Contributing

Contributions are welcome! Please fork the repository and submit a pull request for any improvements or additional sample code.

## License

This repository does not specify a license. Please contact the author for usage permissions if needed.

## Contact

For questions or suggestions, reach out to [BSB](https://github.com/bsb84).

---
_Last updated: 2025-08-19_

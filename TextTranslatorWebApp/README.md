# Text Translator Web Application

A C# ASP.NET Core web application demonstrating Azure AI Translation Services with multiselect dropdown functionality for target languages.

## Features

- **Text Translation**: Translate text into multiple languages simultaneously using Azure AI Translation Service
- **Multiselect Interface**: Choose from 18 different target languages with an intuitive checkbox interface
- **Select All/Clear All**: Convenient buttons to select or deselect all languages at once
- **Error Handling**: Proper error handling and user feedback for configuration issues
- **Copy to Clipboard**: Copy translated text results with a single click
- **Responsive Design**: Bootstrap-based responsive UI that works on desktop and mobile

## Supported Languages

The application supports translation to the following 18 languages:

- Spanish (es)
- French (fr) 
- German (de)
- Italian (it)
- Portuguese (pt)
- Russian (ru)
- Japanese (ja)
- Korean (ko)
- Chinese Simplified (zh)
- Arabic (ar)
- Hindi (hi)
- Turkish (tr)
- Polish (pl)
- Dutch (nl)
- Swedish (sv)
- Danish (da)
- Norwegian (no)
- Finnish (fi)

## Prerequisites

- .NET 8.0 SDK or later
- Azure Translator Service subscription and credentials

## Setup

1. **Clone the repository** and navigate to the TextTranslatorWebApp directory:
   ```bash
   cd TextTranslatorWebApp
   ```

2. **Install dependencies**:
   ```bash
   dotnet restore
   ```

3. **Configure Azure Translator Service**:
   
   Set the following environment variables:
   ```bash
   export TRANSLATOR_KEY="your-azure-translator-key"
   export TRANSLATOR_ENDPOINT="your-azure-translator-endpoint"
   ```
   
   Or add them to your `appsettings.json`:
   ```json
   {
     "TRANSLATOR_KEY": "your-azure-translator-key",
     "TRANSLATOR_ENDPOINT": "your-azure-translator-endpoint"
   }
   ```

4. **Build the application**:
   ```bash
   dotnet build
   ```

5. **Run the application**:
   ```bash
   dotnet run
   ```

6. **Open your browser** and navigate to `https://localhost:5001` or `http://localhost:5000`

## Usage

1. **Enter Text**: Type or paste the text you want to translate in the "Input Text" area
2. **Select Languages**: Choose one or more target languages using the checkboxes:
   - Use individual checkboxes to select specific languages
   - Click "Select All" to select all 18 languages
   - Click "Clear All" to deselect all languages
3. **Translate**: Click the "Translate Text" button to perform the translation
4. **View Results**: Translated text will appear in cards below, organized by language
5. **Copy Results**: Use the "Copy" button on each translation card to copy the text to your clipboard

## Azure Translator Service Setup

To use this application, you need an Azure Translator Service resource:

1. **Create an Azure account** (if you don't have one)
2. **Create a Translator resource** in the Azure portal
3. **Get your credentials**:
   - Translator Key: Found in the "Keys and Endpoint" section
   - Translator Endpoint: Found in the "Keys and Endpoint" section
4. **Configure the application** with your credentials as described in the Setup section

For detailed instructions, see the [Azure Translator Service documentation](https://learn.microsoft.com/en-us/azure/ai-services/translator/).

## Project Structure

```
TextTranslatorWebApp/
├── Pages/
│   ├── Shared/
│   │   └── _Layout.cshtml          # Main layout with navigation
│   ├── Index.cshtml                # Homepage
│   ├── Index.cshtml.cs             # Homepage code-behind
│   ├── Translator.cshtml           # Translator page UI
│   ├── Translator.cshtml.cs        # Translator page logic
│   └── ...
├── wwwroot/                        # Static files (CSS, JS, images)
├── Program.cs                      # Application entry point
├── appsettings.json               # Configuration settings
└── TextTranslatorWebApp.csproj   # Project file
```

## Technologies Used

- **ASP.NET Core 8.0**: Web framework
- **Razor Pages**: Server-side rendering
- **Azure.AI.Translation.Text**: Azure Translator SDK
- **Bootstrap 5**: UI framework
- **Bootstrap Icons**: Icon library
- **JavaScript**: Client-side interactivity

## Error Handling

The application includes comprehensive error handling:

- **Configuration Errors**: Clear messages when Azure credentials are missing
- **Translation Errors**: Individual error handling per language translation
- **Validation Errors**: Client and server-side validation for required fields
- **Network Errors**: Graceful handling of network connectivity issues

## Contributing

This project is part of the AI-102 certification sample code repository. Contributions are welcome to improve the functionality or add new features related to Azure AI services.

## License

This project follows the same license as the parent repository.
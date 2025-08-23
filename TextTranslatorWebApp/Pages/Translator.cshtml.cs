using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Azure.AI.Translation.Text;
using Azure;
using System.ComponentModel.DataAnnotations;

namespace TextTranslatorWebApp.Pages;

public class TranslatorModel : PageModel
{
    private readonly ILogger<TranslatorModel> _logger;
    private readonly IConfiguration _configuration;

    public TranslatorModel(ILogger<TranslatorModel> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    [BindProperty]
    [Required(ErrorMessage = "Please enter text to translate")]
    [Display(Name = "Text to translate")]
    public string InputText { get; set; } = string.Empty;

    [BindProperty]
    [Required(ErrorMessage = "Please select at least one target language")]
    [Display(Name = "Target Languages")]
    public List<string> SelectedLanguages { get; set; } = new List<string>();

    public Dictionary<string, string> TranslatedTexts { get; set; } = new Dictionary<string, string>();

    public string? ErrorMessage { get; set; }

    // Available languages for translation
    public Dictionary<string, string> AvailableLanguages { get; } = new Dictionary<string, string>
    {
        { "es", "Spanish" },
        { "fr", "French" },
        { "de", "German" },
        { "it", "Italian" },
        { "pt", "Portuguese" },
        { "ru", "Russian" },
        { "ja", "Japanese" },
        { "ko", "Korean" },
        { "zh", "Chinese (Simplified)" },
        { "ar", "Arabic" },
        { "hi", "Hindi" },
        { "tr", "Turkish" },
        { "pl", "Polish" },
        { "nl", "Dutch" },
        { "sv", "Swedish" },
        { "da", "Danish" },
        { "no", "Norwegian" },
        { "fi", "Finnish" }
    };

    public void OnGet()
    {
        // Initialize page
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            var translatorKey = _configuration["TRANSLATOR_KEY"] ?? Environment.GetEnvironmentVariable("TRANSLATOR_KEY");
            var translatorEndpoint = _configuration["TRANSLATOR_ENDPOINT"] ?? Environment.GetEnvironmentVariable("TRANSLATOR_ENDPOINT");
            var translatorRegion = _configuration["TRANSLATOR_REGION"] ?? Environment.GetEnvironmentVariable("TRANSLATOR_REGION");

            if (string.IsNullOrWhiteSpace(translatorKey) || string.IsNullOrWhiteSpace(translatorEndpoint))
            {
                ErrorMessage = "Translation service is not configured. Please set TRANSLATOR_KEY and TRANSLATOR_ENDPOINT environment variables.";
                return Page();
            }

            var credential = new AzureKeyCredential(translatorKey);
            var client = new TextTranslationClient(credential, new Uri(translatorEndpoint));

            TranslatedTexts.Clear();

            foreach (var targetLanguage in SelectedLanguages)
            {
                try
                {
                    var response = await client.TranslateAsync(targetLanguage, InputText);
                    var translation = response.Value.FirstOrDefault();
                    
                    if (translation != null && translation.Translations.Any())
                    {
                        var translatedText = translation.Translations.First().Text;
                        var languageName = AvailableLanguages.GetValueOrDefault(targetLanguage, targetLanguage);
                        TranslatedTexts[languageName] = translatedText;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error translating to {Language}", targetLanguage);
                    var languageName = AvailableLanguages.GetValueOrDefault(targetLanguage, targetLanguage);
                    TranslatedTexts[languageName] = $"Translation error: {ex.Message}";
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during translation");
            ErrorMessage = $"An error occurred during translation: {ex.Message}";
        }

        return Page();
    }
}
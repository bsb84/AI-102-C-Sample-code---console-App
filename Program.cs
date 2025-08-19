using Azure;
using System;
using Azure.AI.TextAnalytics;

namespace LanguageDetectionExample
{
    class Program
    {
        // This example requires environment variables named "LANGUAGE_KEY" and "LANGUAGE_ENDPOINT"
       
        static string languageKey = Environment.GetEnvironmentVariable("LANGUAGE_KEY");
        static string languageEndpoint = Environment.GetEnvironmentVariable("LANGUAGE_ENDPOINT");

        private static readonly AzureKeyCredential credentials = new AzureKeyCredential(languageKey);
        private static readonly Uri endpoint = new Uri(languageEndpoint);

        // Example method for detecting the language of textShShweta Shwejosh
        static void LanguageDetectionExample(TextAnalyticsClient client)
        {
            DetectedLanguage detectedLanguage = client.DetectLanguage("Ce document est rédigé en Français.");
            Console.WriteLine("Language:");
            Console.WriteLine($"\t{detectedLanguage.Name},\tISO-6391: {detectedLanguage.Iso6391Name},\tscore:{detectedLanguage.ConfidenceScore} \n ");
        }

        // Example method for extracting key phrases from text
        static void KeyPhraseExtractionExample(TextAnalyticsClient client)
        {
            var response = client.ExtractKeyPhrases(@"Dr. Smith has a very modern medical office, and she has great staff.");

            // Printing key phrases
            Console.WriteLine("Key phrases:");

            foreach (string keyphrase in response.Value)
            {
                Console.WriteLine($"\t{keyphrase}");
            }
        }

        static void EntityRecognitionExample(TextAnalyticsClient client)
        {
            var response = client.RecognizeEntities("Microsoft was founded by Bill Gates and Paul Allen in 1975.");
            // Printing entities
            Console.WriteLine(" Named Entities:");
            foreach (var entity in response.Value)
            {
                Console.WriteLine($"\tText: {entity.Text},\tCategory: {entity.Category},\tSub-Category: {entity.SubCategory}");
                Console.WriteLine($"\t\tScore: {entity.ConfidenceScore:F2},\tLength: {entity.Length},\tOffset: {entity.Offset}\n");
            }


            
        }

        static void RecognizePIIExample(TextAnalyticsClient client)
        {
            string document = "Call our office at 312-555-1234, or send an email to support@contoso.com.";

            PiiEntityCollection entities = client.RecognizePiiEntities(document).Value;

            Console.WriteLine($"Redacted Text: {entities.RedactedText}");
            if (entities.Count > 0)
            {
                Console.WriteLine($"Recognized {entities.Count} PII entit{(entities.Count > 1 ? "ies" : "y")}:");
                foreach (PiiEntity entity in entities)
                {
                    Console.WriteLine($"Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
                }
            }
            else
            {
                Console.WriteLine("No entities were found.");
            }
        }


        static void SentimentAnalysisExample(TextAnalyticsClient client)
        {
            // Example text for sentiment analysis
            string document = "I had a wonderful experience! The rooms were wonderful and the staff was helpful.";
            // Analyze sentiment
            DocumentSentiment documentSentiment = client.AnalyzeSentiment(document);
            // Print overall sentiment
            Console.WriteLine($"Overall sentiment: {documentSentiment.Sentiment}");
            Console.WriteLine($"Positive score: {documentSentiment.ConfidenceScores.Positive}");
            Console.WriteLine($"Neutral score: {documentSentiment.ConfidenceScores.Neutral}");
            Console.WriteLine($"Negative score: {documentSentiment.ConfidenceScores.Negative}");
        }





        static void Main(string[] args)
        {
            if (string.IsNullOrWhiteSpace(languageKey) || string.IsNullOrWhiteSpace(languageEndpoint))
            {
                Console.WriteLine("Error: Please set the LANGUAGE_KEY and LANGUAGE_ENDPOINT environment variables.");
                return;
            }

            try
            {

                Console.Write("LanguageDetectionExample shown ");

                // Example method for detecting the language of text

                var clientLD = new TextAnalyticsClient(endpoint, credentials);
                LanguageDetectionExample(clientLD);

                Console.Write("Press for next example.");
                                
                Console.ReadKey();

                Console.Write("KeyPhraseExtractionExample shown Press for next example.");

                // Example method for extracting key phrases from text

                var clientKPE = new TextAnalyticsClient(endpoint, credentials);
                KeyPhraseExtractionExample(clientKPE);

                Console.Write("KeyPhraseExtractionExample shown Press for next example.");
                Console.ReadKey();


                // Example method for recognizing entities in text`
                var clientRE = new TextAnalyticsClient(endpoint, credentials);
                EntityRecognitionExample(clientRE);

                Console.Write("EntityRecognitionExample shown Press for next example.");
                Console.ReadKey();

                // Example method for recognizing PII entities in text
                  var clientPII = new TextAnalyticsClient(endpoint, credentials);
                RecognizePIIExample(clientPII);

                Console.Write("RecognizePIIExample shown Press for next example.");
                Console.ReadKey();


                // Example method for sentiment analysis
                 var clientSA = new TextAnalyticsClient(endpoint, credentials);
                SentimentAnalysisExample(clientSA);
                Console.Write("SentimentAnalysisExample shown Press for next example.");
                Console.ReadKey();



            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }

    }
}
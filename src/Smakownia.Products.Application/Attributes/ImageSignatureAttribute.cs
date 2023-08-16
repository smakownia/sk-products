using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Smakownia.Products.Application.Attributes;

public class ImageSignatureAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not IFormFile file)
        {
            return new ValidationResult(GetErrorMessage());
        }

        using var reader = new BinaryReader(file.OpenReadStream());
        var signatures = _fileSignatures.Values.SelectMany(x => x).ToList();
        var headerBytes = reader.ReadBytes(_fileSignatures.Max(m => m.Value.Max(n => n.Length)));
        bool isValid = signatures.Any(signature => headerBytes.Take(signature.Length).SequenceEqual(signature));

        if (!isValid)
        {
            return new ValidationResult(GetErrorMessage());
        }

        return ValidationResult.Success;
    }

    public static string GetErrorMessage()
    {
        return "This image signature is not allowed";
    }

    private static readonly Dictionary<string, List<byte[]>> _fileSignatures = new()
    {
        { ".png", new List<byte[]> { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } } },
        { ".jpg", new List<byte[]>
            {
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xEE },
                new byte[] { 0xFF, 0xD8, 0xFF, 0xDB },
            }
        },
    };
}
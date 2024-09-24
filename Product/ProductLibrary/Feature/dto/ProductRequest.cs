namespace ProductLibrary.Feature.dto;

public class ProductRequest
{
    public string Code { get; set; } = default!;
    public string? Name { get; set; } = default;
    public string? Category { get; set; } = default;
}

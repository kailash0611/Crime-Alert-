using CrimeAlert.Models;

public class ImageModel
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public byte[] ImageData { get; set; }
    public admin_addcriminals Criminal { get; set; }
}


using Booking_Dance_Bussiness.Service.Interfaces;
using Booking_Dance_Data.ImageDTO;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class FilebaseController : ControllerBase
{
    private readonly IFirebaseService _firebaseService;

    public FilebaseController(IFirebaseService firebaseService)
    {
        _firebaseService = firebaseService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadImage(IFormFile file, [FromForm] string userId)
    {
        var filePath = await _firebaseService.UploadImage(file, "studio", userId);
        return Ok(new { filePath });
    }

    [HttpGet("get_all")]
    public async Task<IActionResult> GetAllObjects()
    {
        var objectsWithLinks = await _firebaseService.GetAllObjects();
        return Ok(objectsWithLinks);
    }

    
    [HttpGet("get")]
    public async Task<IActionResult> GetImage(string filePath)
    {
        var (imageStream, userId) = await _firebaseService.GetImage2(filePath);

        if (imageStream == null)
        {
            return NotFound();
        }

        // Read the MemoryStream to a byte array
        byte[] imageBytes;
        using (var memoryStream = new MemoryStream())
        {
            await imageStream.CopyToAsync(memoryStream);
            imageBytes = memoryStream.ToArray();
        }
         var imageResponse = new ImageResponseDto
    {
       
        UserId = userId
    };
        // Return the image file
        return Ok(imageResponse);
    }


    [HttpPost("get_ByUserId")]
    public async Task<IActionResult> GetImageUserId(string userId)
    {
        var objects = await _firebaseService.GetObjectsByUserId(userId);

        return Ok(objects);
    }

    
    [HttpPost("get_ByUserId_2")]
    public async Task<IActionResult> GetImageUserId2(string userId)
    {
        var objects = await _firebaseService.GetObjectsByUserId2(userId);

        return Ok(objects);
    }

    [HttpGet("Get-Image")]
    public async Task<IActionResult> GetImage3(string filePath)
    {
        var (imageStream, userId) = await _firebaseService.GetImage2(filePath);

        if (imageStream == null)
        {
            return NotFound();
        }

        // Read the MemoryStream to a byte array
        byte[] imageBytes;
        using (var memoryStream = new MemoryStream())
        {
            await imageStream.CopyToAsync(memoryStream);
            imageBytes = memoryStream.ToArray();
        }

        // Return the image file
        return File(imageBytes, "image/jpeg"); // Adjust content type as needed
    }
    // Controllers/FilebaseController.cs
    [HttpGet("get_image_paths")]
    public async Task<IActionResult> GetImagePaths()
    {
        var imagePaths = await _firebaseService.GetImagePaths();
        return Ok(imagePaths);
    }

    [HttpGet("get_image_paths2")]
    public async Task<IActionResult> GetImagePaths2(string filePath,string folder)
    {
        var imagePaths = await _firebaseService.GetImagePath(filePath,folder);
        return Ok(imagePaths);
    }


}

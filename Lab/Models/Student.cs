using System.ComponentModel.DataAnnotations;

namespace Lab.Models;

public class Student
{

    public int Id { get; set; }

    [Required(ErrorMessage = "Tên không được để trống")]
    [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên phải có ít nhất 4 ký tự")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Email không được để trống")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "Email không hợp lệ - Phải có đuôi @gmail.com")]
    public string? Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Mật khẩu không được để trống")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$", ErrorMessage = "Mật khẩu phải chứa ít nhất 1 chữ hoa, 1 chữ thường, 1 số và 1 ký tự đặc biệt")]
    public string? Password { get; set; }

    [Required(ErrorMessage = "Branch không được để trống")]
    public Branchs? Branch { get; set; }

    [Required(ErrorMessage = "Giới tính không được để trống")]
    public Gender? Gender { get; set; }
    public bool IsRegular { get; set; } // Hệ: true - chính qui; false - phi chính qui
    
    [Required(ErrorMessage = "Địa chỉ không được để trống")]
    [DataType(DataType.MultilineText)]
    public string? Address { get; set; }

    [DataType(DataType.Date)]
    [Required(ErrorMessage = "Ngày sinh không được để trống")]
    public DateTime? DateOfBirth { get; set; }
    // public string? AvatarPath { get; set; }    
    public string? Avatar { get; set; }

    [Range(0, 10, ErrorMessage = "Điểm phải nằm trong khoảng từ 0 đến 10")]
    [Required(ErrorMessage = "Điểm không được để trống")]
    public double? Point { get; set; }
}
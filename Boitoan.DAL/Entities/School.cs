using Boitoan.DAL.Entities;

namespace Boitoan.DAL.Entities;

public class School: Base
{
    public string Name { get; set; }
    public Specializations[] Specializations { get; set; }
}

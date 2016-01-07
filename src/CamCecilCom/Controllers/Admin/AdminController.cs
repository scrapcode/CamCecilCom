using System;

namespace CamCecilCom.Controllers
{
    private AdminRepository _repository;
    
    public AdminController(AdminRepository repository)
    {
        _repository = repository;
    }
}
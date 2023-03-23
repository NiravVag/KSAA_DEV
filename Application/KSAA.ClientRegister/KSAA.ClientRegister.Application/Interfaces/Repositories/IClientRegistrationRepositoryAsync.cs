﻿using KSAA.Domain.Entities.ClientRegister;
using KSAA.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSAA.ClientRegister.Application.Interfaces.Repositories
{
    public interface IClientRegistrationRepositoryAsync : IGenericRepositoryAsync<ClientRegistration>
    {
    }
}

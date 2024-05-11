using AutoMapper;
using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class BackupService : IBackupService
    {
        private readonly IRepositoryManager _repository;

        public BackupService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public void CreateBackup()
        {
            _repository.Backup.CreateBackup();
        }
    }
}

using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BackupRepository : RepositoryBase<string>, IBackupRepository
    {
        private RepositoryContext _repositoryContext;

        public BackupRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void CreateBackup()
        {
            var backupDirectoryPath = "C:\\OmNomBoxBackups";
            var backupFileName = $"OmNomBox_backup_{DateTime.UtcNow:yyyyMMddHHmmss}.bak";

            var backupPath = Path.Combine(backupDirectoryPath, backupFileName);
            var backupCommand = $"BACKUP DATABASE OmNomBox TO DISK = '{backupPath}'";
            _repositoryContext.Database.ExecuteSqlRaw(backupCommand);
        }
    }
}

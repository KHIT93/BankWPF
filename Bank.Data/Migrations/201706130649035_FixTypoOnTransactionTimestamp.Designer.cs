// <auto-generated />
namespace Bank.Data.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class FixTypoOnTransactionTimestamp : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(FixTypoOnTransactionTimestamp));
        
        string IMigrationMetadata.Id
        {
            get { return "201706130649035_FixTypoOnTransactionTimestamp"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
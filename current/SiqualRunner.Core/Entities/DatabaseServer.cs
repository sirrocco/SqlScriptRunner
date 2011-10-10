using System;
using System.Collections.Generic;
using System.Linq;
using SiqualRunner.Infrastructure;
using Undrtake.Infrastructure.Entity;

namespace SiqualRunner.Core.Entities
{
  public class DatabaseServer : EntityWithTypedId<int>
  {
    private IList<SiqualFile> _files;
    public virtual IList<SiqualFile> Files
    {
      get { return _files ?? (_files = new List<SiqualFile>()); }
      set { _files = value; }
    }


    public virtual string ServerAddress { get; set; }
    public virtual string DatabaseName { get; set; }
    public virtual string UserName { get; set; }
    public virtual string Password { get; set; }
    public virtual bool UseWindowsAuth { get; set; }

    public virtual bool IsDefault { get; set; }

    public virtual void AddFileRange ( IList<SiqualFile> files )
    {
      if (Files == null)
        Files = new List<SiqualFile>();

      foreach (SiqualFile file in files)
      {
        Files.Add(file);
      }
    }

    public override string ToString ( )
    {
      string s = ServerAddress + " - " + DatabaseName;
      if (IsDefault)
        s += " - d";
      return s;
    }

    public virtual IList<SiqualFile> GetNotRanScripts ( )
    {
      return (from file in Files
              let statusForThisServer = file.FileStatuses.FirstOrDefault(x => x.RanFor != null && x.RanFor.Id == Id)
              where statusForThisServer != null && statusForThisServer.RunStatus == EnumRunStatus.NotRan
              select file).OrderBy(x => x.FileName, new NumericThenAlphabeticComparer()).ToList();
    }

    public virtual SiqualFile GetScript ( int fileId )
    {
      return (from file in Files
              where file.Id == fileId
              select file).FirstOrDefault();
    }

    public virtual IList<SiqualFile> GetScripts ( IList<int> ids )
    {
      return (from file in Files
              where ids.Contains(file.Id)
              select file
              ).OrderBy(x => x.FileName, new NumericThenAlphabeticComparer()).ToList();
    }

    public virtual void MarkFilesAsRan ( IList<int> list )
    {
      IEnumerable<SiqualFile> filesToMark = (from file in Files
                                             where list.Contains(file.Id)
                                             select file);

      foreach (SiqualFile file in filesToMark)
      {
        FileStatus existingStatus = file.FileStatuses.FirstOrDefault(x => x.RanFor != null && x.RanFor.Id == Id) ??
                                    file.SaveStatusFor(this, EnumRunStatus.Success, TimeSpan.Zero);

        existingStatus.RunStatus = EnumRunStatus.Success;
        existingStatus.ErrorMessage = "";
      }
    }
  }
}
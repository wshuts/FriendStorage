﻿using FriendStorage.Model;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Collections.Generic;

namespace FriendStorage.UI.Wrapper
{
  public class FriendWrapper : ModelWrapper<Friend>
  {
    public FriendWrapper(Friend model) : base(model)
    {
      
    }

    protected override void InitializeCollectionProperties(Friend model)
    {
      if (model.Emails == null)
      {
        throw new ArgumentException("Emails cannot be null");
      }
      Emails = new ChangeTrackingCollection<FriendEmailWrapper>(
        model.Emails.Select(e => new FriendEmailWrapper(e)));
      RegisterCollection(Emails, model.Emails);
    }

    protected override void InitializeComplexProperties(Friend model)
    {
      if (model.Address == null)
      {
        throw new ArgumentException("Address cannot be null");
      }
      Address = new AddressWrapper(model.Address);
      RegisterComplex(Address);
    }

    public int Id
    {
      get { return GetValue<int>(); }
      set { SetValue(value); }
    }

    public int IdOriginalValue => GetOriginalValue<int>(nameof(Id));

    public bool IdIsChanged => GetIsChanged(nameof(Id));

    public int FriendGroupId
    {
      get { return GetValue<int>(); }
      set { SetValue(value); }
    }

    public int FriendGroupIdOriginalValue => GetOriginalValue<int>(nameof(FriendGroupId));

    public bool FriendGroupIdIsChanged => GetIsChanged(nameof(FriendGroupId));
    
    public string FirstName
    {
      get { return GetValue<string>(); }
      set { SetValue(value); }
    }

    public string FirstNameOriginalValue => GetOriginalValue<string>(nameof(FirstName));

    public bool FirstNameIsChanged => GetIsChanged(nameof(FirstName));

    public string LastName
    {
      get { return GetValue<string>(); }
      set { SetValue(value); }
    }

    public string LastNameOriginalValue => GetOriginalValue<string>(nameof(LastName));

    public bool LastNameIsChanged => GetIsChanged(nameof(LastName));

    public DateTime? Birthday
    {
      get { return GetValue<DateTime?>(); }
      set { SetValue(value); }
    }

    public DateTime? BirthdayOriginalValue => GetOriginalValue<DateTime?>(nameof(Birthday));

    public bool BirthdayIsChanged => GetIsChanged(nameof(Birthday));

    public bool IsDeveloper
    {
      get { return GetValue<bool>(); }
      set { SetValue(value); }
    }

    public bool IsDeveloperOriginalValue => GetOriginalValue<bool>(nameof(IsDeveloper));

    public bool IsDeveloperIsChanged => GetIsChanged(nameof(IsDeveloper));

    public AddressWrapper Address { get; private set; }

    public ChangeTrackingCollection<FriendEmailWrapper> Emails { get; private set; }

    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if(string.IsNullOrWhiteSpace(FirstName))
      {
        yield return new ValidationResult("Firstname is required",
          new[] { nameof(FirstName) });
      }
      if(IsDeveloper && Emails.Count==0)
      {
        yield return new ValidationResult("A developer must have an email-address",
          new[] { nameof(IsDeveloper), nameof(Emails) });
      }
    }
  }
}

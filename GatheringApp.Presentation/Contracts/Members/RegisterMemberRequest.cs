using GatheringApp.Domain.ValueObjects;

namespace GatheringApp.Presentation.Contracts.Members;

public  sealed record  RegisterMemberRequest
(
   
   string FirstName,
    string lastName,
   string Email 
    
    );

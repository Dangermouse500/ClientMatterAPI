namespace Client.Matter.Services.Mapping
{
    public class ClientMatterMappingProfile : Profile
    {
        public ClientMatterMappingProfile()
        {
            CreateMap<ClientEf, ClientDto>();
            CreateMap<AddressEf, AddressDto>();
            CreateMap<PeopleEf, PeopleDto>();
            CreateMap<MatterEf, MatterDto>();
        }
    }
}
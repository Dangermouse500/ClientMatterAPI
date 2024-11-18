namespace Client.Matter.Services.Implementations
{
    public class MatterService(IMapper _mapper, IMatterRepository _matterRepository) : IMatterService
    {
        public async Task<MatterDto> GetMatterByIdAsync(string matterId)
        {
            return _mapper.Map<MatterDto>(await _matterRepository.GetMatterByIdAsync(matterId));
        }
    }
}
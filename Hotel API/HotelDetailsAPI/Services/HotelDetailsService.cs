using HotelDetailsAPI.Models;
using MongoDB.Driver;

namespace HotelDetailsAPI.Services
{
	public class HotelDetailsService
	{
		private readonly IMongoCollection<HotelDetails> _hotelDetailsCollection;

		public HotelDetailsService(IMongoDatabase database)
		{
			_hotelDetailsCollection = database.GetCollection<HotelDetails>("HotelDetails");
		}

		public async Task<HotelDetails> GetHotelByIdAsync(int id)
		{
			return await _hotelDetailsCollection.Find(hotel => hotel._id == id).FirstOrDefaultAsync();
		}

		public async Task<List<HotelDetails>> GetAllHotelsAsync()
		{
			return await _hotelDetailsCollection.Find(hotel => true).ToListAsync();
		}

		public async Task CreateHotelAsync(HotelDetails hotel)
		{
			await _hotelDetailsCollection.InsertOneAsync(hotel);
		}

		public async Task UpdateHotelAsync(int id, HotelDetails updatedHotel)
		{
			await _hotelDetailsCollection.ReplaceOneAsync(hotel => hotel._id == id, updatedHotel);
		}

		public async Task DeleteHotelAsync(int id)
		{
			await _hotelDetailsCollection.DeleteOneAsync(hotel => hotel._id == id);
		}
	}
}

public static class DbInitializer
{
  public static void Initialize(TrilloContext context)
  {

    // Check if any data exist.
    if (context.Hotels.Any())
    {
      return;
    }

    var hotels = new Hotel[] {
      new Hotel{Name="The Venetian Macao",Gallery=["https://www.bring-you.info/wp-content/uploads/2021/05/Guia-Lighthouse-viewing-Grand-Lisboa-Hotel.jpg","https://image-tc.galaxy.tf/wijpeg-9vualzt3dbue0hi00ba4q49ub/chatwalhotelnyc-c-004-build-crop.jpg?width=1920"],Description=["This is a Hotel located in Macao", "The Venetian Macao offers an exceptional luxury experience, featuring spacious suites with elegant décor, a wide range of dining options, and world-class entertainment. Whether you're visiting for business or leisure, the hotel provides a unique blend of comfort and sophistication, all within the vibrant heart of Macao."],SubDescription=["Close to the beach", "Breakfast included", "Free airport shuttle", "Free wifi in all rooms", "Air conditioning and heating", "Pets allowed", "We speak all languages", "Perfect for families"],Address="Marco, China",TotalVote=99, TotalRating=7.8, Bookings=[]},
      new Hotel{Name="The Parisian Macao",Gallery=["https://www.china-briefing.com/news/wp-content/uploads/2019/04/China-Briefing-Shanghai-Industry-Economics-and-Policy.jpg","https://dynamic-media-cdn.tripadvisor.com/media/photo-s/01/ea/d8/2d/grand-canal-shoppes.jpg?w=600&h=-1&s=1"],Description=["This is a Hotel located in China", "Situated in the heart of Shanghai, this hotel offers a perfect blend of modern luxury and traditional Chinese elegance. Guests can enjoy stunning views of the city skyline, indulge in exquisite dining experiences, and unwind in spacious rooms with state-of-the-art amenities. Whether you’re here for business or pleasure, this hotel promises an unforgettable stay with top-notch service and unmatched comfort."],SubDescription=["Close to the beach", "Breakfast included", "Free airport shuttle", "Free wifi in all rooms", "Air conditioning and heating", "Pets allowed", "We speak all languages", "Perfect for families"],Address="Shanghai, China",TotalVote=96, TotalRating=8.8},
      new Hotel{Name="Nina Hotel Tsuen Wan West",Gallery=["https://inafarawayland.com/wp-content/uploads/2021/11/Auckland-5.jpg","https://dynamic-media-cdn.tripadvisor.com/media/daodao/photo-s/0c/7b/d9/f2/exterior-night.jpg?w=600&h=-1&s=1"],Description=["This is a Hotel located in Auckland", "Nestled in the vibrant city of Auckland, this hotel offers a perfect mix of contemporary design and laid-back New Zealand charm. With panoramic views of the harbor and easy access to the city’s top attractions, guests can enjoy spacious rooms, personalized service, and a range of on-site dining options. Whether you’re exploring the city or attending a business meeting, this hotel provides a welcoming retreat with a touch of local hospitality."],SubDescription=["Close to the beach", "Breakfast included", "Free airport shuttle", "Free wifi in all rooms", "Air conditioning and heating", "Pets allowed", "We speak all languages", "Perfect for families"],Address="Auckland, New Zealand",TotalVote=79, TotalRating=8.6},
      new Hotel{Name="Nina Hotel Causeway Bay",Gallery=["https://www.newzealandscapes.co.nz/cdn/shop/files/NZ-Landscape-Lake-Wanaka-Tree.jpg?v=1690859938","https://cf.bstatic.com/xdata/images/hotel/max1024x768/118479281.jpg?k=d5090d90ae7919b4637f2d7d08d0ae0df7517e4185eaebed5a5907e53cd3801d&o=&hp=1"],Description=["This is a Hotel located in NZ", "Located in the picturesque town of Wanaka, this hotel offers a serene escape surrounded by stunning mountain landscapes and crystal-clear lakes. Guests can relax in cozy, modern rooms with breathtaking views, and enjoy outdoor activities like hiking, skiing, and lake adventures. Whether you’re seeking adventure or tranquility, this hotel provides the perfect base for exploring the natural beauty of the region."],SubDescription=["Close to the beach", "Breakfast included", "Free airport shuttle", "Free wifi in all rooms", "Air conditioning and heating", "Pets allowed", "We speak all languages", "Perfect for families"],Address="Wanaka, New Zealand",TotalVote=39, TotalRating=9.8},
      new Hotel{Name="Conrad Macao",Gallery=["https://imageio.forbes.com/specials-images/imageserve/67018dbf99b9cd9195c243d1/The-Forbidden-City--Beijing/0x0.jpg?format=jpg&width=960","https://cf.bstatic.com/xdata/images/hotel/max1024x768/444100282.jpg?k=5e70c960ea21dc975984f647631bc7bc86f04ee273278029a24067da129924d4&o="],Description=["This is a Hotel located in Beijing", "Located in the heart of Beijing, this hotel offers an exquisite blend of modern luxury and traditional Chinese elegance. With its close proximity to iconic landmarks like the Forbidden City and Tiananmen Square, guests can experience both the rich history and vibrant culture of the city. The hotel features spacious, elegantly designed rooms, top-tier dining options, and impeccable service, making it the perfect choice for both business and leisure travelers."],SubDescription=["Close to the beach", "Breakfast included", "Free airport shuttle", "Free wifi in all rooms", "Air conditioning and heating", "Pets allowed", "We speak all languages", "Perfect for families"],Address="Beijing, China",TotalVote=27, TotalRating=7.4},
      new Hotel{Name="Legend Palace Hotel",Gallery=["https://www.cathaypacific.com/content/dam/focal-point/cx/inspiration/2023/12/How-to-get-to-Guangzhou-from-Hong-Kong-How-to-get-Gettyimages-HERO.renditionimage.900.600.jpg","https://cf.bstatic.com/xdata/images/hotel/max1024x768/76198529.jpg?k=a796fcdc88c43b4260062989c5d25e98dc6ea6dc5c2651a333acea5fcb4a6a0c&o="],Description=["This is a Hotel located in Guangzhou", "Situated in the heart of Guangzhou, this hotel combines traditional Southern Chinese charm with modern luxury. Guests can enjoy stunning views of the Pearl River and experience world-class dining, wellness facilities, and spacious rooms equipped with all the latest amenities. Whether you're visiting for business, shopping, or sightseeing, the hotel offers convenient access to Guangzhou's thriving commercial and cultural districts, ensuring a memorable stay in one of China’s most dynamic cities."],SubDescription=["Close to the beach", "Breakfast included", "Free airport shuttle", "Free wifi in all rooms", "Air conditioning and heating", "Pets allowed", "We speak all languages", "Perfect for families"],Address="Guangzhou, China",TotalVote=30, TotalRating=7.9},
      new Hotel{Name="Royal Plaza Hotel",Gallery=["https://thehkhub.com/wp-content/uploads/2024/08/best-places-to-visit-shenzhen.jpg","https://cf.bstatic.com/xdata/images/hotel/max1024x768/252246544.jpg?k=1e0e1187669624e23fcc0982aba976fa8e63b324e07764ab4c057775b0e50d68&o="],Description=["This is a Hotel located in Shenzhen", "Located in the dynamic city of Shenzhen, this hotel offers a blend of contemporary comfort and cutting-edge design. With its prime location in the city’s bustling business district, guests enjoy easy access to top shopping, dining, and entertainment hubs. The hotel features sleek, modern rooms, a variety of on-site dining options, and state-of-the-art amenities, making it an ideal choice for both business professionals and leisure travelers seeking convenience and luxury."],SubDescription=["Close to the beach", "Breakfast included", "Free airport shuttle", "Free wifi in all rooms", "Air conditioning and heating", "Pets allowed", "We speak all languages", "Perfect for families"],Address="Shenzhen, China",TotalVote=15, TotalRating=8.2},
    };
    context.Hotels.AddRange(hotels);
    context.SaveChanges();

    var reviews = new Review[] {
      new Review{UserId=101,Hotel=hotels[0], Body="This hotel exceeded our expectations! The staff was incredibly friendly and helpful, and the rooms were spacious and clean. The breakfast was fantastic, and the location couldn’t be better – right in the heart of the city.",Rating=8.8},
      new Review{UserId=102,Hotel=hotels[0],Body="A wonderful stay! The hotel is modern, and the amenities are top-notch. The pool area was relaxing, and the restaurant served delicious food. I also appreciated the free airport shuttle. Will definitely return!",Rating=7.8},
      new Review{UserId=103,Hotel=hotels[1],Body="Perfect for a weekend getaway. The room was comfortable, and the view from the balcony was breathtaking. The hotel is just steps away from the beach, and the service was exceptional. Highly recommend!",Rating=6.8},
      new Review{UserId=104,Hotel=hotels[1],Body="Great value for money. The hotel is well-located, and everything was within walking distance. The staff was welcoming, and we loved the free Wi-Fi in all rooms. Will be back next time we're in town.",Rating=8.8},
      new Review{UserId=105,Hotel=hotels[2],Body="This hotel made our trip memorable. The breakfast spread was incredible, with a wide variety of options. The rooms were clean, and the staff were attentive. It’s the perfect place for both families and couples.",Rating=8.5},
      new Review{UserId=106,Hotel=hotels[2],Body="A comfortable stay with all the necessary amenities. The air conditioning was a lifesaver during the hot weather. The hotel also offers great family-friendly services, which made our stay much more enjoyable.",Rating=8.9},
      new Review{UserId=107,Hotel=hotels[3],Body="The hotel was amazing, from the stunning design to the impeccable service. I loved the fact that pets are allowed, and my dog enjoyed the stay as much as we did. The only downside was the noise from the street at night.",Rating=9.8},
      new Review{UserId=101,Hotel=hotels[3],Body="We had an unforgettable stay here! The staff went above and beyond to make us feel at home. The location was perfect – close to shopping and dining, with a beautiful view. Definitely a top choice for future trips!",Rating=8.2},

      new Review{UserId=106,Hotel=hotels[4], Body="This hotel exceeded our expectations! The staff was incredibly friendly and helpful, and the rooms were spacious and clean. The breakfast was fantastic, and the location couldn’t be better – right in the heart of the city.",Rating=8.8},
      new Review{UserId=102,Hotel=hotels[4],Body="A wonderful stay! The hotel is modern, and the amenities are top-notch. The pool area was relaxing, and the restaurant served delicious food. I also appreciated the free airport shuttle. Will definitely return!",Rating=7.8},
      new Review{UserId=103,Hotel=hotels[5],Body="Perfect for a weekend getaway. The room was comfortable, and the view from the balcony was breathtaking. The hotel is just steps away from the beach, and the service was exceptional. Highly recommend!",Rating=6.8},
      new Review{UserId=104,Hotel=hotels[5],Body="Great value for money. The hotel is well-located, and everything was within walking distance. The staff was welcoming, and we loved the free Wi-Fi in all rooms. Will be back next time we're in town.",Rating=8.8},
      new Review{UserId=105,Hotel=hotels[6],Body="This hotel made our trip memorable. The breakfast spread was incredible, with a wide variety of options. The rooms were clean, and the staff were attentive. It’s the perfect place for both families and couples.",Rating=8.5},
      new Review{UserId=107,Hotel=hotels[6],Body="A comfortable stay with all the necessary amenities. The air conditioning was a lifesaver during the hot weather. The hotel also offers great family-friendly services, which made our stay much more enjoyable.",Rating=8.9},
    };

    context.Reviews.AddRange(reviews);
    context.SaveChanges();

    var orders = new Order[] {
      new Order{UserId=101,Amount=200.3,GuestName="Ella"},
      new Order{UserId=102,Amount=229,GuestName="Hank"},
      new Order{UserId=103,Amount=93.4,GuestName="Mark"},
      new Order{UserId=104,Amount=3784.4,GuestName="Tala"},
      new Order{UserId=105,Amount=278743.4,GuestName="Ada"},
      new Order{UserId=106,Amount=3985,GuestName="Hui"},
      new Order{UserId=107,Amount=3875.6,GuestName="Kswi"}
    };

    context.Orders.AddRange(orders);
    context.SaveChanges();


    Random random = new Random();
    DateTime currentDate = DateTime.Now;
    DateTime firstDayOfNextMonth = new DateTime(currentDate.Year, currentDate.Month, 1).AddMonths(1);// Get next months date
    int numberOfBookingsPerHotel = DateTime.DaysInMonth(firstDayOfNextMonth.Year, firstDayOfNextMonth.Month); // Get next months days
    int totalHotels = hotels.Length; // Assuming hotels is already defined

    // Initialize a list to store the bookings
    List<Booking> bookingsList = new List<Booking>();

    // Generate bookings for each hotel
    for (int i = 0; i < totalHotels; i++)
    {
      for (int j = 0; j < numberOfBookingsPerHotel; j++)
      {
        // Generate a random price, for example between 50 and 500
        double randomPrice = Math.Round(random.NextDouble() * (500 - 50) + 50);

        // Get the date for each day of the next month
        DateTime bookingDate = firstDayOfNextMonth.AddDays(j).Date;

        // Create a new booking and add it to the list
        bookingsList.Add(new Booking
        {
          Hotel = hotels[i], // Assign the current hotel
          Order = null, // Set the order ID to null
          Date = bookingDate,
          Price = randomPrice, // Assign the randomly generated price
          isAvailable = true // Set availability to true
        });
      }
    }

    // Convert the list to an array if needed
    var bookings = bookingsList.ToArray();

    context.Bookings.AddRange(bookings);
    context.SaveChanges();
  }
}
// Monitor tweet velocity of a stream
// count the number of tweets flowing through the system

tweetVelocity = GROUP twitterInput2
    BY id SAMPLERATE 60
    AGG BCC.count("MIN") AS tweetsPerMinute;

// Count the total number of tweets analyzed per session
// start counting tweets when a user first loads the page

cumulativeCount = GROUP twitterInput1
    BY id SAMPLERATE 5
    AGG BCC.count("ALL") AS totalTweetsSeen;


// Perform complex real-time analysis on streaming data
// listen to Twitter in real-time for users that fit your target demographic

potentialBuyers = FILTER twitterInput3 WHERE
    !BCC.isEmpty(placeName)
    &&
    BCC.contains(text, "house hunting");

// vet and qualify them in real-time

topLeads = FILTER potentialBuyers WHERE
    userFollowerCount >= 15000 &&
    BCC.contains(userProfile, "investor") &&
    userLocation == "Savannah, GA" &&
    userLang == "en";


// Social media monitoring
// Send an apology, coupon code, or immediately put in touch with escalation team, while simultaneously alerting customer service rep

INPUT twitterInput4
OUTPUT customerServiceAlerts
OUTPUT contactTheseCustomers
OUTPUT customerComplaintsPerHour

// listen for users who are unhappy with your product or service

customerServiceAlerts = FILTER twitterInput4 WHERE
    userFollowerCount > 2000 &&
    BCC.contains(text, "sucks") &&
    BCC.contains(text, "yourProduct");

contactTheseCustomers = TRANSFORM customerServiceAlerts WITH
    userScreenName AS customerName,
    userName AS twitterHandle,
    text AS customerComplaint;

// BrightContext can broadcast this feed directly to your customer service team for rectification - within seconds of the original complaint
// simultaneously identify your biggest brand champions and reward them

brandChampions = FILTER twitterInput4 WHERE
    userFollowerCount >= 5000 &&
    BCC.contains(text, "love") &&
    BCC.contains(text, "yourProduct") &&
    BCC.inList(urlMediaList, "http://www.yourbrand.com");

// Combine multiple data sources on the fly
//ingest stock data and social media discussions to correlate stock performance with market buzz

INPUT stocksDataStream;
INPUT twitterInput5;
OUTPUT out;

positiveMicrosoftMentions = FILTER twitterInput5 WHERE
    BCC.inList(text, ["MSFT", "windows 8", "windows phone", "bill gates"]) &&
    BCC.contains(text, "awesome");

// perform mathematical calculations on streaming data

averageMSFTgrowth = GROUP stocksDataStream BY stockUpdate
    AGG BCC.avg("30SEC", stockPrice) AS avgGrowth;

// weave together two or more streams on the fly and create the output fields you need
microsoftSocialStocks = MERGE positiveMicrosoftMentions, averageMSFTgrowth
    WITH (positiveMicrosoftMentions, avgGrowth) AS stockBuzzCorrelation;

// Harvest media being shared around a trending topic 
// output the stream to a dashboard, leaderboard display, or database

INPUT twitterInput6;
OUTPUT trendingFashionMedia;

relevantTweets = FILTER twitterInput6 WHERE
    !BCC.isEmpty(mediaList) &&
    !BCC.isEmpty(urls) &&
    retweetCount >= 50 &&
    BCC.contains(text, "fashion");

trendingFashionMedia = TRANSFORM relevantTweets WITH
    (relevantTweets.mediaList) AS trendingImages,
    (relevantTweets.urls) AS trendingLinks;

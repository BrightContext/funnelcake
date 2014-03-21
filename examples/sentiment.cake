INPUT twitter;
OUTPUT topsentiment;

sentimentStream = TAG twitter
  WITH FIELD sentiment
  VALUES
    "positive"
      WHERE FC.regexMatch(text, "cute|cool|awesome|sweet|great|best"),
    "negative"
      WHERE FC.regexMatch(text, "hmm|weird|ugly|terrible|fake"),
    "funny"
      WHERE FC.regexMatch(text, "lol"),
    "neutral"
      DEFAULT
;

topsentiment = GROUP sentimentStream
  BY sentiment
  REFRESHRATE 5
  AGG
    FC.count("HOUR")
      AS c
  LEADERBOARD
    TOP 100
    USING c
      AS leaderboard
;

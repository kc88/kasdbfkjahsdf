<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
  <title>Kongregate Javascript API example</title>
  <script src='https://ajax.googleapis.com/ajax/libs/jquery/2.2.0/jquery.min.js'></script>
  <script src='https://cdn1.kongregate.com/javascripts/kongregate_api.js'></script>
</head>
 
<body style='background-color:white'>
  <span id='init'>Initializing...</span>
  <div id='content' style='display:none'>
    <div>Kongregate API Loaded!</div>
    <div id='username'></div>
    <div id='user_id'></div>
    <button id='login' style='display:none'
            onclick='kongregate.services.showRegistrationBox()'>Sign in/register</button>
  </div>
 
  <script type='text/javascript'>
kongregate.mtx.addEventListener("adsAvailable", function(e:Event):void{
  // Ads are now available, calls to kongregate.mtx.showIncentivizedAd() will work
});
 
kongregate.mtx.addEventListener("adsUnavailable", function(e:Event):void{
  // Ads are no longer available, calls to kongregate.mtx.showIncentivizedAd() will fail
});
 
kongregate.mtx.addEventListener("adOpened", function(e:Event):void{
  // An ad is being displayed
});
 
kongregate.mtx.addEventListener("adCompleted", function(e:Event):void{
  // An ad has completed successfully, and the player should be rewarded
});
 
kongregate.mtx.addEventListener("adAbandoned", function(e:Event):void{
  // Ad ad has been closed before completion, the player should not be rewarded
});
 
kongregate.mtx.initializeIncentivizedAds();

  </script>
</body>
</html>

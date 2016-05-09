  <script type='text/javascript'>
	function Function1(arg):void
	{ 
		alert( arg ); 
	}

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

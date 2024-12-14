mergeInto(LibraryManager.library,
{
	InitGame_js: function ()
	{
		InitGame();
	},

	InitLeaderboard: function ()
	{
		InitLeaderboard();
	},
	
	SetLeaderboardScores: function (nameLB, score)
	{
		SetLeaderboardScores(UTF8ToString(nameLB), score);
	},
	
	GetLeaderboardScores: function (nameLB, maxPlayers, quantityTop, quantityAround, photoSizeLB, auth)
	{
		GetLeaderboardScores(UTF8ToString(nameLB), maxPlayers, quantityTop, quantityAround, UTF8ToString(photoSizeLB), auth);
	},

	FullAdShow: function ()
	{
		FullAdShow();
	},

    RewardedShow: function (id)
	{
		RewardedShow(id);
	},

	ReviewInternal: function()
	{
		Review();
	},
	
	PromptShowInternal: function()
	{
		PromptShow();
	},
	
	StickyAdActivityInternal: function(show)
	{
		StickyAdActivity(show);
	},
	
	GetURLFromPage: function () {
        var returnStr = (window.location != window.parent.location) ? document.referrer : document.location.href;
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
		
        return buffer;
    },
	
	OpenURL: function (url) {
		window.open(UTF8ToString(url), "_blank");
	
		//var a = document.createElement("a");
		//a.setAttribute("href", UTF8ToString(url));
		//a.setAttribute("target", "_blank");
		//a.click();
	},
	
	SetToLeaderboard : function(value)
	{
		ysdk.getLeaderboards()
	.then(lb => {
		// Без extraData.
		lb.setLeaderboardScore('leaderboard', value);
	});
	},
	
	GetLang: function () {
		var lang = ysdk.environment.i18n.lang;
		var bufferSize = lengthBytesUTF8(lang) + 1;
		var buffer = _malloc(bufferSize);
		stringToUTF8(lang, buffer, bufferSize);
		return buffer;
	},

BombFromAdYan: function () {
	var check = 0;
    ysdk.adv.showRewardedVideo({
        callbacks: {
            onOpen: () => {
                console.log('Video ad open.');
                myGameInstance.SendMessage("ad", "StopBeforeAd");
            },
            onRewarded: () => {
                console.log('Rewarded!');
				check = 1;
            },
            onClose: () => {
                console.log('Video ad closed.');
				if (check === 1) { myGameInstance.SendMessage("ad", "BombFromAd"); }
                myGameInstance.SendMessage("ad", "ResumeAfterAd");
            },
            onError: (e) => {
                console.error('Error while open video ad:', e);
                // Дополнительная обработка ошибки
            }
        }
    });
},

});

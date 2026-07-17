mergeInto(LibraryManager.library, {

  // -------------------------
  // STRING MESSAGE
  // -------------------------
  SendStringMessage: function (messagePtr) {
    const message = UTF8ToString(messagePtr);

    console.log("Sidestep2 String message:", message);

    window.dispatchEvent(new CustomEvent("Sidestep2-string-message", {
      detail: message
    }));
  },



  // -------------------------
  // SCENE CHANGE
  // -------------------------
  SignalHighscore: function (highscore) {
 
    console.log("[Sidestep2] New highscore:", highscore);

    window.dispatchEvent(new CustomEvent("Sidestep2-highscore", {
      detail: highscore
    }));
  },

});
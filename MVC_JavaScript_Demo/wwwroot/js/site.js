// Write your JavaScript code.

function onBegin(target) {
  var resultsPlace = $(target);
  resultsPlace.removeClass("hidden");
  resultsPlace.addClass("show");
}

function onSuccess(data, target) {
  $(target).html(data);
};

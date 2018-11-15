
var nav = new DayPilot.Navigator("nav");
nav.showMonths = 3;
nav.selectMode = "week";
nav.locale = "pt-br";
nav.onTimeRangeSelected = function (args) {
    dp.startDate = args.start;
    dp.update();
};
nav.init();

var dp = new DayPilot.Calendar("dp");
dp.locale = "pt-br";
// view
dp.viewType = "Week";
dp.theme = "calendar_transparent";
// event creating
dp.onTimeRangeSelected = function (args) {
    var name = prompt("New event name:", "Event");
    if (!name) return;
    var e = new DayPilot.Event({
        start: args.start,
        end: args.end,
        id: DayPilot.guid(),
        text: name
    });
    dp.events.add(e);
    dp.clearSelection();
};

dp.onEventClick = function (args) {
    alert("clicked: " + args.e.id());
};

dp.init();

var e = new DayPilot.Event({
    start: DayPilot.Date.today().addHours(12),
    end: DayPilot.Date.today().addHours(15),
    id: DayPilot.guid(),
    text: "Special event"
});
dp.events.add(e);
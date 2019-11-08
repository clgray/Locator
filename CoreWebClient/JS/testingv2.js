function WriteTestEnd() {
    document.getElementById('endTest').innerHTML = "Вы уверены?&nbsp&nbsp<a href=\"/Testing.aspx?isEnd=true\">Да</a>&nbsp&nbsp&nbsp<a href=\"#\" onclick=\"EndTest(false)\">Нет</a>";
}

function EndTest(isEnd) {
    if (isEnd == false)
        document.getElementById('endTest').innerHTML = "<a href='#' onclick='WriteTestEnd();'>Завершить тестирование</a>";
}

function WriteTime(st, ss) {
    if (ss >= 10) {
        var tmp = st + ':' + ss;
    } else {
        var tmp = st + ':0' + ss;
    }
    try{
    document.getElementById('tm').innerHTML = tmp;
    }catch(err){}
}

var st = 0;
var ss = 0;

function showTime() {
    try {
        if (ss >= 10) {
            var tmp = st + ':' + ss;
        } else {
            var tmp = st + ':0' + ss;
        }
        var inner = document.getElementById('tm').innerHTML;
        if (inner != tmp) {
            var vars = inner.split(":");
            st = parseInt(vars[0]);
            ss = parseInt(vars[1]);
        }
    } catch (err) { }
    ss--;
    if (ss == -1) {
        ss = 59;
        st--;
    }
    if (ss < 0 || st < 0) {
        if (document.getElementById('tm') != null) {
            alert('Время прохождения теста истекло.');
            window.location.href = '/Testing.aspx';
        }
    } else {
        WriteTime(st, ss);
        var t = setTimeout('showTime()', 1000);
    }
}

shortcut.add("Esc", function() {
    if (document.getElementById('endTest') != null) {
        WriteTestEnd();
    }
});

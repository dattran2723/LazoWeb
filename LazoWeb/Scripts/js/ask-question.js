$(document).ready(function () {
    $("#btn-first").click(function () {
        $("#question-second, #question-third").collapse("hide");
        $(this).toggleClass("open");
        $("#btn-second, #btn-third").removeClass("open");
    });
    $("#btn-second").click(function () {
        $("#question-first, #question-third").collapse("hide");
        $(this).toggleClass("open");
        $("#btn-first, #btn-third").removeClass("open");
    });
    $("#btn-third").click(function () {
        $("#question-second, #question-first").collapse("hide");
        $(this).toggleClass("open");
        $("#btn-second, #btn-first").removeClass("open");
    });

    var arrQuestion = [
        {
            question: "Câu hỏi 1?",
            answer:"Câu trả lời cho câu hỏi 1"
        },
        {
            question: "Câu hỏi 2?",
            answer: "Câu trả lời cho câu hỏi 2"
        },
        {
            question: "Câu hỏi 3?",
            answer: "Câu trả lời cho câu hỏi 3 "
        }
    ];
    for (i = 0; i < arrQuestion.length; i++) {
        $('#question' + (i + 1)).html((i + 1) + ". " + arrQuestion[i].question);
        $('#answer' + (i+1)).html(arrQuestion[i].answer);
    }
})
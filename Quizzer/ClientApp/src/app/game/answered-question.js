define(["require", "exports"], function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var AnsweredQuestion = /** @class */ (function () {
        function AnsweredQuestion(targetPlayerName, text, otherPlayerAnswers) {
            this.targetPlayerName = targetPlayerName;
            this.text = text;
            this.otherPlayerAnswers = otherPlayerAnswers;
        }
        return AnsweredQuestion;
    }());
    exports.AnsweredQuestion = AnsweredQuestion;
});
//# sourceMappingURL=answered-question.js.map
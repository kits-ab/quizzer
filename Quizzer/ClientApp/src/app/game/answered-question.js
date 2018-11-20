define(["require", "exports"], function (require, exports) {
    "use strict";
    Object.defineProperty(exports, "__esModule", { value: true });
    var AnsweredQuestion = /** @class */ (function () {
        function AnsweredQuestion(targetPlayerId, text, answers) {
            this.targetPlayerId = targetPlayerId;
            this.text = text;
            this.answers = answers;
        }
        return AnsweredQuestion;
    }());
    exports.AnsweredQuestion = AnsweredQuestion;
});
//# sourceMappingURL=answered-question.js.map
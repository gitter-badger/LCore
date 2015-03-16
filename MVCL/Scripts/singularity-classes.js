var Singularity;
(function (Singularity) {
    var AutoDefinition = (function () {
        function AutoDefinition(source) {
            if (source) {
                this.validateInput = source.validateInput;
                this.injectDefaultInputValue = source.injectDefaultInputValue;
                this.ignoreErrors = source.ignoreErrors;
                this.logErrors = source.logErrors;
                this.logExecution = source.logExecution;
                this.timeExecution = source.timeExecution;
                this.cacheResults = source.cacheResults;
                this.retryTimes = source.retryTimes;
                this.resultAsArray = source.resultAsArray;

                this.defaultResult = source.defaultResult;
                this.defaultResult = source.defaultResult;
                this.overrideResult = source.overrideResult;
            }
        }
        return AutoDefinition;
    })();
})(Singularity || (Singularity = {}));
//# sourceMappingURL=singularity-classes.js.map

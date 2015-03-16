
module Singularity {

    class AutoDefinition {

        validateInput: Boolean;
        injectDefaultInputValue: boolean;

        ignoreErrors: boolean;
        logErrors: boolean;

        logExecution: boolean;
        timeExecution: boolean;
        makeAsync: boolean;
        cacheResults: boolean;
        retryTimes: number;

        resultAsArray: boolean;
        defaultResult: any;
        overrideResult: any;

        constructor(source?: AutoDefinition) {

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
    }


}

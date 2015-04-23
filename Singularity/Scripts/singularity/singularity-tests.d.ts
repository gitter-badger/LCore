/// <reference path="singularity-core.d.ts" />
declare class SingularityTests {
    testErrors: string[];
    addTest: (name: string, testFunc: () => any, requirement?: string) => void;
    addCustomTest: (name: string, testFunc: () => any, requirement?: string) => void;
    addMethodTest: (ext: SingularityMethod, target?: any, args?: any[], compare?: any, requirement?: string) => void;
    addAssertTest: (name: string, result: any, compare: any, requirement?: string) => void;
    addFailsTest: (ext: SingularityMethod, target: any, args: any[], expectedError?: string, requirement?: string) => void;
    runTests: (display: boolean) => string;
    listTests: () => string;
    listMissingTests: () => string;
    resolveTests: () => void;
    constructor();
}
declare class SingularityTest {
    name: string;
    testFunc: Function;
    index: number;
    requirement: string;
    testResult: any;
    constructor(name: string, testFunc: Function, index: number, requirement?: string);
}
declare var singTests: SingularityModule;
declare function SingularityAddTest(name: string, testFunc: () => any, requirement?: string): void;
declare function SingularityAddCustomTest(name: string, testFunc: Function, requirement?: string): void;
declare function SingularityAddMethodTest(ext: SingularityMethod, target?: any, args?: any[], compare?: any, requirement?: string): void;
declare function SingularityAddAssertTest(name: string, result: any, compare: any, requirement?: string): void;
declare function SingularityAddFailsTest(ext: SingularityMethod, target: any, args: any[], expectedError?: string, requirement?: string): void;
declare function SingularityRunTests(display?: boolean): string;
declare function SingularityListTests(): string;
declare function SingularityListMissingTests(): string;
declare function MethodAddFailsTest(caller: any, args: any[], expectedError?: string, requirement?: string): void;
declare function MethodAddCustomTest(testFunc: () => any, requirement?: string): void;
declare function MethodAddSimpleTest(caller: any, args: any[], result?: any, requirement?: string): void;

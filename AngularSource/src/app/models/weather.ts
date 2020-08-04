export class Weather {
    public constructor(
        public weatherKey?: string,
        public weatherText?: string,
        public weatherValue?: string,
        public weatherEpochTime?: number
    ) { }
}
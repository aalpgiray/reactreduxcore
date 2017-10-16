import { StopType } from "../enums/StopType";
import { Route } from "react-router-dom";
import { Base } from "./Base";

export class Stop extends Base {
    public route: Route;
    public stopType: StopType;
}
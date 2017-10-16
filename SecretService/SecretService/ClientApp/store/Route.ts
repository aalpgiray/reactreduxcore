import { Base } from "./Base";
import { Stop } from "./Stop";
import { User } from "./User";

export class Route extends Base {
    public requestDate: Date;
    public validUntil: Date;
    public requester: User;
    public stops: Stop[];
    public arrivalTime: Date;
}
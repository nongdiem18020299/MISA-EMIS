import BaseApi from "../../baseApi/BaseApi";

class RoomApi extends BaseApi{
    constructor(){
        super();
        this.controller = "/api/v1/Rooms";
    }
}

export default new RoomApi();
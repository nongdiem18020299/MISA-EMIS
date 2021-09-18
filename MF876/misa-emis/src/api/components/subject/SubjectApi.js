import BaseApi from "../../baseApi/BaseApi";

class SubjectApi extends BaseApi{
    constructor(){
        super();
        this.controller = "/api/v1/Subjects";
    }
}

export default new SubjectApi();
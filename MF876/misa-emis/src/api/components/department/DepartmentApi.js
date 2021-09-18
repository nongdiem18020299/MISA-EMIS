import BaseApi from "../../baseApi/BaseApi";

class DepartmentApi extends BaseApi{
    constructor(){
        super();
        this.controller = "/api/v1/Departments";
    }
}

export default new DepartmentApi();
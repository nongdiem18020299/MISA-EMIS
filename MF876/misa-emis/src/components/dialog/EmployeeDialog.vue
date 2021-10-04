<template>
  <div class="employee-dialog d-flex">
    <div class="employee-form">
      <div class="e-form-content d-flex">
        <div class="e-form-img-container">
          <div class="select-img">
            <div class="select-img-container">
              <div class="select-img-icon"></div>
              <input
                type="file"
                name="file"
                id="file"
                class="img-input"
                data-file="File"
                accept=".jpg, .jpeg, .png, .gif"
              />
            </div>
            <div class="img-btn"><label for="file">Chọn ảnh</label></div>
            <div class="label-info">
              <div class="label-name" v-if="!Employee.fullName">Họ và tên</div>
              <div class="label-name" v-else>{{ Employee.fullName }}</div>
              <div class="label-code" v-if="!Employee.employeeCode">
                Số hiệu cán bộ
              </div>
              <div class="label-code" v-else>{{ Employee.employeeCode }}</div>
            </div>
          </div>
        </div>
        <div class="e-form-detail">
          <div class="form-icon-question"></div>
          <div class="form-icon-close" @click="closeForm"></div>
          <div class="form-detail-title">
            {{ formTitle }} hồ sơ Cán bộ, giáo viên
          </div>
          <div class="user-info">
            <div class="form-row d-flex">
              <div class="form-item d-flex">
                <div class="form-item-label d-flex">
                  Họ và tên <span> *</span>
                </div>
                <base-input
                  :inputName="'Họ và tên'"
                  :type="'text'"
                  :modelValue.sync="Employee.fullName"
                  ref="fullName"
                  @keyup.native="validateForm('fullName')"
                  tabindex="1"
                  v-tooltip.right="fullName"
                  :isRequired="true"
                ></base-input>
              </div>
              <div class="form-item d-flex form-item-left">
                <div class="form-item-label d-flex">
                  Số hiệu cán bộ <span> *</span>
                </div>
                <base-input
                  :type="'text'"
                  :modelValue.sync="Employee.employeeCode"
                  :inputName="'Số hiệu cán bộ'"
                  ref="employeeCode"
                  @keyup.native="validateForm('employeeCode')"
                  tabindex="2"
                  v-tooltip.right="employeeCode"
                  :isRequired="true"
                ></base-input>
              </div>
            </div>
            <div class="form-row d-flex">
              <div class="form-item d-flex">
                <div class="form-item-label d-flex">Số điện thoại</div>
                <base-input
                  :type="'text'"
                  :modelValue.sync="Employee.phoneNumber"
                  :inputName="'Số điện thoại'"
                  ref="phoneNumber"
                  @keyup.native="validateForm('phoneNumber')"
                  tabindex="3"
                  v-tooltip.right="phoneNumber"
                  :isPhoneNumber="true"
                ></base-input>
              </div>
              <div class="form-item d-flex form-item-left">
                <div class="form-item-label d-flex">Email</div>
                <base-input
                  :type="'text'"
                  :modelValue.sync="Employee.email"
                  :inputName="'Số điện thoại'"
                  ref="email"
                  @keyup.native="validateForm('email')"
                  tabindex="4"
                  v-tooltip.right="email"
                  :isEmail="true"
                ></base-input>
              </div>
            </div>
            <div class="form-row d-flex">
              <div class="form-item d-flex">
                <div class="form-item-label d-flex">Tổ bộ môn</div>
                <base-dropdown
                  :type="'text'"
                  :modelValue.sync="Employee.departmentName"
                  :selectList="departments"
                  :nameDrop="'department'"
                  tabindex="5"
                ></base-dropdown>
              </div>
              <div class="form-item d-flex form-item-left">
                <div class="form-item-label d-flex">Môn dạy</div>
                <multi-checkbox
                  :selectList="subjects"
                  :nameDrop="'subject'"
                  :selectedItem.sync="Employee.subjectNameList"
                  :limit="1"
                  tabindex="6"
                >
                </multi-checkbox>
              </div>
            </div>
            <div class="form-row d-flex">
              <div class="form-item d-flex">
                <div class="form-item-label d-flex">QL kho, phòng</div>
                <multi-checkbox
                  :selectList="rooms"
                  :nameDrop="'room'"
                  :selectedItem.sync="Employee.roomNameList"
                  :limit="3"
                  tabindex="7"
                ></multi-checkbox>
              </div>
            </div>
            <div class="form-row d-flex">
              <div class="form-item d-flex">
                <div class="form-item-checkbox d-flex">
                  <base-checkbox
                    :isChecked.sync="Employee.trainingStatus"
                    tabindex="8"
                  ></base-checkbox>
                </div>
                <div class="form-checkbox-label">Trình độ nghiệp vụ QLTB</div>
              </div>
              <div class="form-item d-flex">
                <div class="form-item-checkbox d-flex">
                  <base-checkbox
                    :isChecked.sync="Employee.workStatus"
                    tabindex="9"
                  ></base-checkbox>
                </div>
                <div class="form-checkbox-label">Đang làm việc</div>
              </div>
              <div class="item-checkbox">
                <div class="form-item d-flex" v-show="!Employee.workStatus">
                  <div class="form-item-label d-flex">Ngày nghỉ việc</div>
                  <div class="form-item-input">
                    <date-picker
                      v-model="Employee.dayOff"
                      format="DD/MM/YYYY"
                      placeholder="__/__/____"
                      tabindex="10"
                    ></date-picker>
                    <!-- <input type="date" " /> -->
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="e-form-footer">
        <div
          class="close-btn form-footer-btn"
          @click="closeForm"
          tabindex="11"
        >
          Đóng
        </div>
        <div class="save-btn form-footer-btn" @click="saveForm" tabindex="12">
          Lưu
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import EmployeeApi from "../../api/components/employee/EmployeeApi";
import BaseCheckbox from "../base/BaseCheckbox.vue";
import BaseDropdown from "../base/baseDropdown.vue";
import BaseInput from "../base/BaseInput.vue";
import MultiCheckbox from "../base/MultiCheckbox.vue";
import DatePicker from "vue2-datepicker";
import "vue2-datepicker/index.css";
import moment from "moment";
// import draggable from "vuedraggable";
export default {
  name: "EmployeeDialog",
  components: {
    BaseInput,
    BaseDropdown,
    MultiCheckbox,
    BaseCheckbox,
    DatePicker,
  },
  props: {
    Employee: [],
    NewEmployeeCode: String,
    departments: [],
    subjects: [],
    rooms: [],
    formState: String,
  },
  // mounted(){
  //   setTimeout(()=>{
  //     this.Employee.email = "true";
  //   }, 2000);
  // },
  mounted() {
    // console.log(this.$refs.employeeCode);
    this.$refs.fullName.$el.lastChild.focus();
  },
  data() {
    return {
      employee: {},
      formTitle: "",
      fullName: "",
      failList: [],
      employeeCode: "",
      phoneNumber: "",
      email: "",
    };
  },
  created() {
    this.setFormTitle();
  },
  methods: {
    focusNext() {
      if (!this.Employee.workStatus) {
        this.focusDayOff();
      } else {
        this.focusClose();
      }
    },
    focusDayOff() {
      this.$refs["dayOff"].$el.querySelector("input").focus();
    },
    focusClose() {
      this.$refs["closeBtn"].$el.querySelector("input").focus();
    },
    /**
     * Hàm focus vào input bên trong component
     * CreateBy: NTDIEM(02/09/2021)
     */
    focusInput(inputName, index) {
      // console.log(this.$refs[inputName].$el.querySelector("input"));
      this.$refs[inputName].$el
        .querySelector("input")
        .setAttribute("tabindex", index);
      this.$refs[inputName].$el.querySelector("input").focus();
    },
    validateForm(e) {
      var inputValue = this.$refs[e].$el.firstChild.value;
      //validate các trường bắt buộc không được để trống
      if (!inputValue && this.$refs[e].isRequired) {
        console.log(this.$refs[e]);
        this.$refs[e].failState = true;
        this[e] = this.$refs[e].inputName + " không được để trống";
        this.failList.push(e);
      } else {
        this[e] = "";
        this.$refs[e].failState = false;
        const index = this.failList.indexOf(e);
        if (index > -1) {
          this.failList.splice(index, 1);
        }
      }

      //Validate số điện thoại
      if (inputValue && this.$refs[e].isPhoneNumber) {
        const tel = /(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b/;
        if (!tel.test(inputValue)) {
          this.$refs[e].failState = true;
          this[e] = "Số điện thoại không đúng định dạng";
          this.failList.push(e);
        } else {
          this.$refs[e].failState = false;
          const index = this.failList.indexOf(e);
          if (index > -1) {
            this.failList.splice(index, 1);
          }
        }
      }

      //Validate Email
      if (inputValue && this.$refs[e].isEmail) {
        const re =
          /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        if (!re.test(String(inputValue).toLowerCase())) {
          this.$refs[e].failState = true;
          this[e] = "Email không đúng định dạng";
          this.failList.push(e);
        } else {
          this.$refs[e].failState = false;
          const index = this.failList.indexOf(e);
          if (index > -1) {
            this.failList.splice(index, 1);
          }
        }
      }
    },
    setFormTitle() {
      if (this.formState == "put") {
        this.formTitle = "Sửa";
      } else {
        this.formTitle = "Thêm";
      }
    },
    closeForm() {
      this.$emit("closeForm");
    },
    focusFirstInputFail() {
      var field = this.failList[0];
      this.$refs[field].$el.querySelector("input").focus();
    },
    saveForm() {
      this.employee = this.Employee;
      for (let ref in this.$refs) {
        this.validateForm(ref);
      }

      if (this.failList.length > 0) {
        this.focusFirstInputFail();
      } else {
        this.employee = this.formatForm(this.employee);
        var employeeData = JSON.stringify(this.employee);
        console.log(employeeData );
        if (this.formState == "post") {
          EmployeeApi.post(employeeData)
            .then((res) => {
              console.log(res);
              this.closeForm();
            })
            .catch((res) => {
              console.log(res);
              this.closeForm();
            });
        } else {
          EmployeeApi.put(this.Employee["employeeId"], employeeData)
            .then((res) => {
              console.log(res);
              this.closeForm();
            })
            .catch((res) => {
              console.log(res);
              this.closeForm();
            });
        }
      }
    },

    formatForm(employee) {
      employee["listRoomId"] = [];
      employee["listSubjectId"] = [];

      for (let room of this.rooms) {
        for (let key in employee["roomNameList"]) {
          if (room["roomName"] == employee["roomNameList"][key]) {
            let newRoom = { RoomId: room["roomId"] };
            employee["listRoomId"].push(newRoom);
          }
        }
      }
      employee["listRoomId"] = JSON.stringify(employee["listRoomId"]);
      for (let subject of this.subjects) {
        for (let key in employee["subjectNameList"]) {
          if (subject["subjectName"] == employee["subjectNameList"][key]) {
            let newSubject = { SubjectId: subject["subjectId"] };
            employee["listSubjectId"].push(newSubject);
          }
        }
      }
      employee["listSubjectId"] = JSON.stringify(employee["listSubjectId"]);
      if (employee["workStatus"]) {
        employee["workStatus"] = 1;
      } else {
        employee["workStatus"] = 0;
      }
      if (employee["trainingStatus"]) {
        employee["trainingStatus"] = 1;
      } else {
        employee["trainingStatus"] = 0;
      }
      for (let department of this.departments) {
        if (department["departmentName"] == employee["departmentName"]) {
          employee["departmentId"] = department["departmentId"];
        }
      }
      delete employee["roomNameList"];
      delete employee["subjectNameList"];
      if (employee["dayOff"])
        employee["dayOff"] = moment(String(employee["dayOff"])).format(
          "YYYY-MM-DD"
        );

      return employee;
    },
    // validate(employee){
    //   con
    // }
  },
  watch: {
    //  Employee(){
    //    validate(this.Employee);
    //  }
  },
};
</script>

<style scoped>
@import "../../css/dialog/employeeDialog.css";
</style>
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
              <div class="label-name">{{ Employee.fullName }}</div>
              <div class="label-code">{{ Employee.employeeCode }}</div>
            </div>
          </div>
        </div>
        <div class="e-form-detail">
          <div class="form-icon-question"></div>
          <div class="form-icon-close" @click="closeForm"></div>
          <div class="form-detail-title">Thêm hồ sơ Cán bộ, giáo viên</div>
          <div class="user-info">
            <div class="form-row d-flex">
              <div class="form-item d-flex">
                <div class="form-item-label d-flex">
                  Họ và tên <span> *</span>
                </div>
                <base-input
                  :type="'text'"
                  :modelValue.sync="Employee.fullName"
                ></base-input>
              </div>
              <div class="form-item d-flex form-item-left">
                <div class="form-item-label d-flex">
                  Số hiệu cán bộ <span> *</span>
                </div>
                <base-input
                  :type="'text'"
                  :modelValue.sync="Employee.employeeCode"
                ></base-input>
              </div>
            </div>
            <div class="form-row d-flex">
              <div class="form-item d-flex">
                <div class="form-item-label d-flex">Số điện thoại</div>
                <base-input
                  :type="'text'"
                  :modelValue.sync="Employee.phoneNumber"
                ></base-input>
              </div>
              <div class="form-item d-flex form-item-left">
                <div class="form-item-label d-flex">Email</div>
                <base-input
                  :type="'text'"
                  :modelValue.sync="Employee.email"
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
                ></base-dropdown>
              </div>
              <div class="form-item d-flex form-item-left">
                <div class="form-item-label d-flex">Môn dạy</div>
                <multi-checkbox
                  :selectList="subjects"
                  :nameDrop="'subject'"
                  :modelValue.sync="Employee.subjectName"
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
                  :modelValue.sync="Employee.roomName"
                ></multi-checkbox>
              </div>
            </div>
            <div class="form-row d-flex">
              <div class="form-item d-flex">
                <div class="form-item-checkbox d-flex">
                  <base-checkbox
                    :isChecked.sync="Employee.trainingStatus"
                  ></base-checkbox>
                </div>
                <div class="form-checkbox-label">Trình độ nghiệp vụ QLTB</div>
              </div>
              <div class="form-item d-flex">
                <div class="form-item-checkbox d-flex">
                  <base-checkbox
                    :isChecked.sync="Employee.workStatus"
                  ></base-checkbox>
                </div>
                <div class="form-checkbox-label">Đang làm việc</div>
              </div>
              <div class="item-checkbox">
                <div class="form-item d-flex" v-show="!Employee.workStatus">
                  <div class="form-item-label d-flex">Ngày nghỉ việc</div>
                  <div class="form-item-input">
                    <input type="date" v-model="Employee.dayOff" />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="e-form-footer">
        <div class="close-btn form-footer-btn" @click="closeForm">Đóng</div>
        <div class="save-btn form-footer-btn" @click="saveForm">Lưu</div>
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
// import draggable from "vuedraggable";
export default {
  name: "EmployeeDialog",
  components: { BaseInput, BaseDropdown, MultiCheckbox, BaseCheckbox },
  props: {
    Employee: [],
    NewEmployeeCode: String,
    departments: [],
    subjects: [],
    rooms: [],
    formState: String,
  },
  created() {},
  methods: {
    closeForm() {
      this.$emit("closeForm");
    },
    saveForm() {
      var employee = this.Employee;
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
      var employeeData = JSON.stringify(employee);
      console.log(employeeData);
      if (this.formState == "post") {
        EmployeeApi.post(employeeData)
          .then((res) => {
            console.log(res);
          })
          .catch((res) => {
            console.log(res);
          });
      } else {
        EmployeeApi.put(this.Employee["employeeId"], employeeData)
          .then((res) => {
            console.log(res);
          })
          .catch((res) => {
            console.log(res);
          });
      }
    },
  },
};
</script>

<style scoped>
@import "../../css/dialog/employeeDialog.css";
</style>
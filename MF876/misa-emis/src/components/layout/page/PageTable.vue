<template>
  <div class="base-table">
    <table>
      <thead>
        <tr>
          <th class="col-check-box"><base-checkbox></base-checkbox></th>
          <th>Số hiệu cán bộ</th>
          <th>Họ và tên</th>
          <th>Số điện thoại</th>
          <th>Tổ bộ môn</th>
          <th>Môn dạy</th>
          <th>QL kho, phòng</th>
          <th>Đào tạo QLTB</th>
          <th>Đang làm việc</th>
          <th class="tool-col"><div class="tool-col"></div></th>
        </tr>
      </thead>
      <tbody>
        <tr
          v-for="(employee, i) in employees"
          :key="i"
          v-bind:class="{ 'even-row': i % 2 != 0 }"
          @dblclick="openForm(employee)"
        >
          <td class="col-check-box">
            <div class="check-box-btn"><base-checkbox></base-checkbox></div>
          </td>
          <td>
            <div :title="employee.employeeCode" class="text-cell">
              {{ employee.employeeCode }}
            </div>
          </td>
          <td>
            <div :title="employee.fullName" class="text-cell col-full-name">
              {{ employee.fullName }}
            </div>
          </td>
          <td>
            <div :title="employee.phoneNumber" class="text-cell">
              {{ employee.phoneNumber }}
            </div>
          </td>
          <td>
            <div :title="employee.departmentName" class="text-cell">
              {{ employee.departmentName }}
            </div>
          </td>
          <td>
            <div :title="employee.subjectName" class="text-cell">
              {{ employee.subjectName }}
            </div>
          </td>
          <td>
            <div :title="employee.roomName" class="text-cell">
              {{ employee.roomName }}
            </div>
          </td>
          <td>
            <div class="text-cell">
              <div
                class="check-icon"
                v-bind:class="{ 'is-checked': employee.trainingStatus}"
              ></div>
            </div>
          </td>
          <td>
            <div class="text-cell">
              <div
                class="check-icon"
                v-bind:class="{ 'is-checked': employee.workStatus}"
              ></div>
            </div>
          </td>
          <td class="tool-col">
            <div class="tool-table d-flex">
              <div class="edit-icon"></div>
              <div class="remove-icon" @click="deleteItem(employee)"></div>
            </div>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
import EmployeeApi from "../../../api/components/employee/EmployeeApi.js";
import BaseCheckbox from "@/components/base/BaseCheckbox";
export default {
  name: "PageTable",
  components: {
    BaseCheckbox,
  },
  data() {
    return {
      employees: [],
    };
  },
  props: {
    departments: [],
    subjects: [],
    rooms: [],
  },
  created() {
    this.loadData();
  },
  methods: {
    /**
     * Hàm load dữ liệu nhân viên
     * CreateBy: NTDIEM(15/09/2021)
     */
    loadData() {
      console.log("getEmployee");
      EmployeeApi.getAll()
        .then((res) => {
          this.formatData(res.data);
          console.log(res);
        })
        .catch((res) => {
          console.log(res);
        });
    },
    formatData(data) {
      for (var employee of data) {
        for (var department of this.departments) {
          if (employee["departmentId"] == department["departmentId"]) {
            employee["departmentName"] = department["departmentName"];
          }
        }
        for (var room of this.rooms) {
          if (employee["roomId"] == room["roomId"]) {
            employee["roomName"] = room["roomName"];
          }
        }
        for (var subject of this.subjects) {
          if (employee["subjectId"] == subject["subjectId"]) {
            employee["subjectName"] = subject["subjectName"];
          }
        }

        if (employee["workStatus"] == 1) {
          employee["workStatus"] = true;
        } else {
          employee["workStatus"] = false;
        }
        if (employee["trainingStatus"] == 1) {
          employee["trainingStatus"] = true;
        } else {
          employee["trainingStatus"] = false;
        }
      }
      this.employees = data;
    },
    openForm(employee) {
      this.$emit("openForm", employee, "put");
    },
    deleteItem(employee) {
      this.$emit("deleteItem", employee);
    },
  },
};
</script>

<style scoped>
@import "../../../css/layout/page/pageBodyTable.css";
@import "../../../css/common/common.css";
</style>
<template>
  <div class="form-dropdown">
    <div class="form-item-input">
      <input :type="type" :value="modelValue" @input="updateInput" />
    </div>
    <div
      @click="openSelectList"
      v-bind:class="[{ 'dropdown-icon-rotage': isDrop }, 'dropdown-icon']"
    ></div>
    <ul class="select-list" v-if="isDrop">
      <li class="d-flex">
        <div class="item-checkbox">
          <input type="checkbox" />
        </div>
        <div class="list-item-content">Tất cả</div>
      </li>
      <li class="d-flex" v-for="(item, i) in selectList" :key="i"
      @click="selectItem(item)"
      >
        <div class="item-checkbox">
          <input type="checkbox" />
        </div>
        <div class="list-item-content">{{ item[nameDrop + "Name"] }}</div>
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "MultiCheckbox",
  props: {
    modelValue: {
      type: [String, Number],
      default: "",
    },
    type: {
      type: String,
      default: "text",
    },
    selectList: [],
    nameDrop: String,
  },
  data() {
    return {
      isDrop: false,
    };
  },
  methods: {
    updateInput(event) {
      this.$emit("update:modelValue", event.target.value);
    },
    openSelectList() {
      if (this.isDrop) {
        this.isDrop = false;
      } else {
        this.isDrop = true;
      }
    },
    selectItem(item){
        this.modelValue = item[this.nameDrop+"Name"];
        this.isDrop = false;
    }
  },
  created() {
  },
};
</script>
<style scoped>
@import "../../css/base/multiCheckbox.css";
</style>
<template>
  <div class="form-dropdown">
    <div class="form-item-input">
      <input :type="type" v-model="selectedItem" />
    </div>
    <div
      @click="openSelectList"
      v-bind:class="[{ 'dropdown-icon-rotage': isDrop }, 'dropdown-icon']"
    ></div>
    <ul class="select-list" v-if="isDrop"  v-click-outside="closeSelectList">
      <li v-for="(item, i) in selectList" :key="i" @click="selectItem(item)">
        {{ item[nameDrop + "Name"] }}
      </li>
    </ul>
  </div>
</template>

<script>
export default {
  name: "BaseDropdown",
  props: {
    id: String,
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
      selectedItem: "",
    };
  },
  methods: {
    openSelectList() {
      if (this.isDrop) {
        this.isDrop = false;
      } else {
        this.isDrop = true;
      }
    },
    selectItem(item) {
      this.selectedItem = item[this.nameDrop + "Name"];
      this.isDrop = false;
    },
    closeSelectList(){
      if(this.isDrop){
        this.isDrop = false;
      }
    }
  },
  created() {
    this.selectedItem = this.modelValue;
  },
  watch: {
    selectedItem() {
      this.$emit("update:modelValue", this.selectedItem);
    },
  },
};
</script>
<style scoped>
@import "../../css/base/baseDropdown.css";
</style>
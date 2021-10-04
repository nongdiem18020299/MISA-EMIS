<template>
  <div class="form-item-input">
    <input
      :type="type"
        :value="modelValue"
        @input="updateInput"
        @focus="onFocus=true"
        v-bind:class="{'border-red' : failState}"
    />
  </div>
</template>

<script>
export default {
  name: "BaseInput",
  props: {
    modelValue: {
      type: [String, Number],
      default: "",
    },
    type: {
      type: String,
      default: "text",
    },
    isRequired: Boolean,
    isEmail: Boolean,
    isPhoneNumber: Boolean,
    inputName: String,
   
  },
  data() {
    return {
      onFocus: false,
       failState: false,
    };
  },
  methods: {
    updateInput(event) {
      this.$emit("update:modelValue", event.target.value);
    },
  },
};
</script>

<style>
@import "../../css/base/baseInput.css"
</style>
import React from "react";
import { useField } from "formik";
import { Form, Label } from "semantic-ui-react";
import { Field } from "react-final-form";

import "./FieldTextInput.scss";

type FieldTextInputProps = {
  placeholder: string;
  name: string;
  type?: string;
  label?: string;
  validate?: any;
};

const FieldTextInput: React.FC<FieldTextInputProps> = (props) => {
  // const [field,meta] = useField(props.name);
  const { placeholder, name, type, label, validate } = props;
  return (
    <Field
      name={name}
      render={({ input, meta }) => (
        <Form.Field error={meta.error && meta.touched}>
          <label className="text-input__label">{label}</label>
          <input {...input} type={type} placeholder={placeholder} />
          {meta.error && meta.touched && (
            <span className="text-input__error">{meta.error}</span>
          )}
        </Form.Field>
      )}
      validate={validate}
    ></Field>
    // <Form.Field error={meta.touched && !!meta.error}>
    //     <label>{props.label}</label>
    //     <input {...field} {...props} />
    //     {meta.touched && meta.error?(
    //         <Label basic color='red'>{meta.error}</Label>
    //     ):null}
    // </Form.Field>
  );
};

export default FieldTextInput;

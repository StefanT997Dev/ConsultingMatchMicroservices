import React from "react";
import { Form, Segment } from "semantic-ui-react";

export default function RegisterForm() {
  const options = [
    { key: "co", text: "Consultant", value: "consultant" },
    { key: "cl", text: "Client", value: "client" },
  ];

  return (
    <Segment inverted style={{width:"30em"}}>
      <Form inverted style={{width:"30em"}}>
        <Form.Select fluid label="Role" options={options} placeholder="Role" />
        <Form.Input fluid label="Display Name" placeholder="Display Name" />
        <Form.Input fluid label="Email" placeholder="Email" />
        <Form.Input fluid label="Password" placeholder="Password" />
        <Form.Input fluid label="Username" placeholder="Username" />
        <Form.Checkbox label="I agree to the Terms and Conditions" />
        <Form.Button>Submit</Form.Button>
      </Form>
    </Segment>
  );
}

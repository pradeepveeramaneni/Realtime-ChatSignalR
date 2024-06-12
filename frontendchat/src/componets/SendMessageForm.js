import { useState } from "react";
import { Button, FormControl, InputGroup, Form } from "react-bootstrap";

const SendMessageForm = ({ sendMessage }) => {
  const [message, setMessage] = useState('')
console.log(sendMessage);
  return (
    <Form
      onSubmit={(e) => {
        e.preventDefault();
        sendMessage(message);
        setMessage(''); // Clear the input after sending the message
      }}
    >
      <InputGroup>
        <FormControl
          placeholder='message...'
          onChange={(e) => setMessage(e.target.value)}
          value={message}
        />
        <InputGroup.Append>
          <Button variant="primary" type="submit" disabled={!message}>
            Send
          </Button>
        </InputGroup.Append>
      </InputGroup>
    </Form>
  );
};

export default SendMessageForm;

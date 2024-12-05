import {
    Box,
    Container,
    Stack,
    Input,
    Button,
    Text,
    Link,
    Heading,
  } from "@chakra-ui/react";
  import { useState } from "react";
  import { registry } from "../services/auth";
  const Registration = () => {

    const [userName, setUserName] = useState("");
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [message, setMessage] = useState("");

    const handleRegister = async () => {
        const result = await registry(userName, email, password); 
    
        if (result.success) {
          setMessage(result.message); 
        } else {
          setMessage(result.message); 
        }
      };

    return (
      <Container
        maxW="md"
        p="6"
        boxShadow="xl"
        borderRadius="lg"
        bg="grey.500"
        mt="8"
      >
        <Heading textAlign="center" size="xl" color="white" mb="6">
          Регистрация
        </Heading>
        <Box as="form">
          <Stack spacing="4">
            <Input  placeholder="Логин" size="lg" focusBorderColor="purple.400" value={userName} onChange={(e) => setUserName(e.target.value)}/>
            <Input  placeholder="E-mail" size="lg" focusBorderColor="purple.400" value={email} onChange={(e) => setEmail(e.target.value)}/>
            <Input
              placeholder="Пароль"
              type="password"
              size="lg"
              focusBorderColor="purple.400"
              value={password} onChange={(e) => setPassword(e.target.value)}
            />
            <Button size="lg" bg="purple.700" color="white" _hover={{ bg: "purple.800" }} onClick={handleRegister}>
              Зарегистрироваться
            </Button>
  
            {/* Разделитель */}
            <Box
              height="1px"
              bg="gray.200"
              my="4"
              borderRadius="full"
              w="full"
            />
  
            {/* Дополнительный текст */}
            <Text textAlign="center" fontSize="sm" color="white">
              Уже есть аккаунт?{" "}
              <Link color="purple.500" href="/login">
                Войти
              </Link>
            </Text>
          </Stack>
        </Box>
        {message && <Text mt="4" color="white">{message}</Text>}
      </Container>
    );
  };
  
  export default Registration;
  
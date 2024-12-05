import { Box, Container, Stack, Input, Button, Text, Link, Heading } from "@chakra-ui/react";
import { useState } from "react";
import { login } from "../services/auth";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [message, setMessage] = useState("");

  const handleLogin = async () => {
    const result = await login(email, password); // Вызов метода login из authService

    if (result.success) {
      setMessage(result.message); // Если вход успешен
    } else {
      setMessage(result.message); // Если ошибка
    }
  };

  return (
    <Container maxW="md" p="6" boxShadow="xl" borderRadius="lg" bg="grey.500" mt="8">
      <Heading textAlign="center" size="xl" color="white" mb="6">
        Вход
      </Heading>
      <Box as="form">
        <Stack spacing="4">
          <Input
            placeholder="Email"
            size="lg"
            focusBorderColor="purple.400"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
          />
          <Input
            placeholder="Пароль"
            type="password"
            size="lg"
            focusBorderColor="purple.400"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
          <Button
            size="lg"
            bg="purple.500"
            color="white"
            _hover={{ bg: "purple.600" }}
            onClick={handleLogin}
          >
            Войти
          </Button>

          {/* Разделитель */}
          <Box height="1px" bg="gray.200" my="4" borderRadius="full" w="full" />

          {/* Дополнительный текст */}
          <Text textAlign="center" fontSize="sm" color="white">
            Нет аккаунта?{" "}
            <Link color="purple.500" href="/register">
              Зарегистрируйтесь
            </Link>
          </Text>
        </Stack>
      </Box>
      {message && <Text mt="4" color="white">{message}</Text>}
    </Container>
  );
};

export default Login;

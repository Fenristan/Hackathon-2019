#include <bcl.h>

#define LIGHT_COUNT 3
#define LEDS_PER_LIGHT 8

bc_led_strip_t led_strip;
static uint32_t _dma_buffer[144 * 4 * 2]; // count * type * 2
const bc_led_strip_buffer_t _led_strip_buffer =
        {
                .type = BC_LED_STRIP_TYPE_RGBW,
                .count = 144,
                .buffer = _dma_buffer
        };

void set_light(int light, uint8_t r, uint8_t g, uint8_t b, uint8_t w)
{
    int i;

    /*for(i = 0; i < LEDS_PER_LIGHT * LIGHT_COUNT; i++)
    {
        bc_led_strip_set_pixel_rgbw(&led_strip, i, 0, 0, 0, 0);
    }*/

    for(i = 0; i < LEDS_PER_LIGHT; i++)
    {
        bc_led_strip_set_pixel_rgbw(&led_strip, light * LEDS_PER_LIGHT + i, r, g, b, w);
    }
}

void application_init(void)
{
    char* serial;

    bc_module_power_init();
    bc_led_strip_init(&led_strip, bc_module_power_get_led_strip_driver(), &_led_strip_buffer);

    set_light(0, 64, 48,  0, 0);
    set_light(1, 64, 60, 56, 0);
    set_light(2,  0, 24, 64, 0);



    bc_led_strip_write(&led_strip);
}